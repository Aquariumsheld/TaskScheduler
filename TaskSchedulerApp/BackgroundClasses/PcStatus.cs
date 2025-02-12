using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace TaskSchedulerApp.BackgroundClasses
{
    public static class PcStatus
    {
        // Felder zur Speicherung des Shutdown- und Schlafmodus-Status
        public static bool _isShuttingDown = false;
        public static bool _isGoingToSleep = false;

        #region Statische Felder für Statuswerte

        private static bool _isProgramOpen = false;
        private static bool _isJustBooted = false;
        private static bool _isUserInactive = false;
        private static bool _isPcLightlyLoaded = false;
        private static bool _areProgramsOpen = false;

        #endregion

        // CancellationTokenSource, um die Hintergrund-Tasks bei Bedarf zu stoppen.
        private static CancellationTokenSource _cts;

        /// <summary>
        /// Initialisiert die PC-Statusüberwachung:
        /// - Abonnieren von Systemereignissen
        /// - Starten der asynchronen Überwachungsschleifen
        /// </summary>
        public static async Task PcStatusUpdate()
        {
            // Abonnieren der Systemereignisse
            SystemEvents.SessionEnding += OnSessionEnding;
            SystemEvents.PowerModeChanged += OnPowerModeChanged;

            // Starte die Hintergrund-Tasks, sofern noch nicht geschehen
            if (_cts == null)
            {
                _cts = new CancellationTokenSource();
                // Starte die kontinuierlichen Überwachungsschleifen.
                // Hier werden beispielhaft:
                // - Der "JustBooted"-Status mit einem Schwellwert von 10 Sekunden,
                // - die Nutzerinaktivität mit 5 Minuten,
                // - die CPU-Auslastung mit einem Schwellenwert von 20%,
                // - das Vorhandensein eines Prozesses (hier "notepad") und
                // - das Vorhandensein mehrerer Programme (hier als Beispiel "notepad")
                // überwacht. Die Intervalle für die Updates sind jeweils 1 Sekunde.
                _ = Task.Run(() => MonitorJustBooted(TimeSpan.FromSeconds(240), _cts.Token));
                _ = Task.Run(() => MonitorUserInactive(TimeSpan.FromMinutes(2), _cts.Token));
                _ = Task.Run(() => MonitorPcLightlyLoaded(20f, _cts.Token));
                _ = Task.Run(() => MonitorProgramsOpen(new string[] { "notepad" }, _cts.Token));
                _ = Task.Run(() => MonitorSingleProgramOpen("ChatGPT", _cts.Token));
            }
        }

        #region Systemereignis-Handler

        public static void OnSessionEnding(object sender, SessionEndingEventArgs e)
        {
            // Wird aufgerufen, wenn eine Abmeldung oder ein Shutdown initiiert wird.
            e.Cancel = true;
            _isShuttingDown = true;
        }

        private static void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            // Bei Suspend wird der PC in den Ruhezustand versetzt.
            if (e.Mode == PowerModes.Suspend)
            {
                _isGoingToSleep = true;
            }
            else if (e.Mode == PowerModes.Resume)
            {
                _isGoingToSleep = false;
            }
        }

        #endregion

        #region Synchrone Statusprüfungen

        /// <summary>
        /// Prüft, ob der PC gerade hochgefahren wurde.
        /// </summary>
        public static bool IsJustBooted(TimeSpan threshold)
        {
            long uptimeMilliseconds = Environment.TickCount64;
            return uptimeMilliseconds < threshold.TotalMilliseconds;
        }

        /// <summary>
        /// Gibt zurück, ob der PC heruntergefahren wird.
        /// </summary>
        public static bool IsShuttingDown()
        {
            return _isShuttingDown;
        }

        /// <summary>
        /// Gibt zurück, ob der PC in den Ruhemodus geht.
        /// </summary>
        public static bool IsGoingToSleep()
        {
            return _isGoingToSleep;
        }

        #region Nutzerinaktivität

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        /// <summary>
        /// Prüft, ob der Nutzer inaktiv ist.
        /// </summary>
        public static bool IsUserInactive(TimeSpan inactivityThreshold)
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO));

            if (!GetLastInputInfo(ref lastInputInfo))
            {
                throw new Exception("Fehler beim Abrufen der letzten Eingabezeit.");
            }

            uint idleTimeMilliseconds = (uint)Environment.TickCount - lastInputInfo.dwTime;
            return idleTimeMilliseconds >= inactivityThreshold.TotalMilliseconds;
        }

        #endregion

        #region CPU-Auslastung

        /// <summary>
        /// Prüft, ob der PC nur wenig ausgelastet ist.
        /// </summary>
        public static bool IsPcLightlyLoaded(float cpuUsageThreshold)
        {
            try
            {
                using (PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
                {
                    // Der erste Wert ist oft 0 – daher ein kurzes Warten
                    cpuCounter.NextValue();
                    Thread.Sleep(1000);
                    float currentCpuUsage = cpuCounter.NextValue();
                    return currentCpuUsage < cpuUsageThreshold;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler beim Abrufen der CPU-Auslastung: " + ex.Message);
                return false;
            }
        }

        #endregion

        #region Offene Programme

        /// <summary>
        /// Prüft, ob bestimmte Programme offen sind.
        /// </summary>
        public static bool AreProgramsOpen(string[] processNames)
        {
            var processes = Process.GetProcesses();
            foreach (var proc in processes)
            {
                try
                {
                    string procName = proc.ProcessName;
                    foreach (string target in processNames)
                    {
                        string targetName = Path.GetFileNameWithoutExtension(target);
                        if (string.Equals(procName, targetName, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
            return false;
        }

        /// <summary>
        /// Prüft, ob ein bestimmtes Programm offen ist.
        /// </summary>
        public static bool IsProgramOpen(string processName)
        {
            return AreProgramsOpen(new string[] { processName });
        }

        #endregion

        #endregion

        #region Hintergrund-Überwachungsschleifen

        /// <summary>
        /// Aktualisiert in einer Endlosschleife _isJustBooted.
        /// </summary>
        private static async Task MonitorJustBooted(TimeSpan threshold, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _isJustBooted = IsJustBooted(threshold);
                await Task.Delay(1000, token);
            }
        }

        /// <summary>
        /// Aktualisiert in einer Endlosschleife _isUserInactive.
        /// </summary>
        private static async Task MonitorUserInactive(TimeSpan inactivityThreshold, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _isUserInactive = IsUserInactive(inactivityThreshold);
                await Task.Delay(1000, token);
            }
        }

        /// <summary>
        /// Aktualisiert in einer Endlosschleife _isPcLightlyLoaded.
        /// </summary>
        private static async Task MonitorPcLightlyLoaded(float cpuUsageThreshold, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _isPcLightlyLoaded = IsPcLightlyLoaded(cpuUsageThreshold);
                await Task.Delay(1000, token);
            }
        }

        /// <summary>
        /// Aktualisiert in einer Endlosschleife _areProgramsOpen.
        /// </summary>
        private static async Task MonitorProgramsOpen(string[] processNames, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _areProgramsOpen = AreProgramsOpen(processNames);
                await Task.Delay(1000, token);
            }
        }

        /// <summary>
        /// Aktualisiert in einer Endlosschleife _isProgramOpen (für einen einzelnen Prozess).
        /// </summary>
        private static async Task MonitorSingleProgramOpen(string processName, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _isProgramOpen = IsProgramOpen(processName);
                await Task.Delay(1000, token);
            }
        }

        #endregion

        #region Update-Methoden (statische Abfragen)

        /// <summary>
        /// Liefert den aktuellen Status, ob der angegebene Prozess läuft.
        /// (Hintergrundüberwachung läuft bereits.)
        /// </summary>
        public static bool UpdateIsProgramOpen()
        {
            return _isProgramOpen;
        }

        /// <summary>
        /// Liefert den aktuellen Status, ob der PC gerade hochgefahren wurde.
        /// </summary>
        public static bool UpdateJustBooted()
        {
            return _isJustBooted;
        }

        /// <summary>
        /// Liefert den aktuellen Status, ob der Nutzer inaktiv ist.
        /// </summary>
        public static bool UpdateUserInactive()
        {
            return _isUserInactive;
        }

        /// <summary>
        /// Liefert den aktuellen Status, ob der PC nur wenig ausgelastet ist.
        /// </summary>
        public static bool UpdatePcLightlyLoaded()
        {
            return _isPcLightlyLoaded;
        }

        /// <summary>
        /// Liefert den aktuellen Status, ob bestimmte Programme offen sind.
        /// </summary>
        public static bool UpdateAreProgramsOpen()
        {
            return _areProgramsOpen;
        }

        #endregion

        #region Asynchrone Wrapper-Methoden (statische Abfragen)

        /// <summary>
        /// Gibt den zuletzt aktualisierten Status zurück, ob ein bestimmter Prozess läuft.
        /// </summary>
        public static Task<bool> IsProgramOpenAsync(string processName)
        {
            return Task.FromResult(_isProgramOpen);
        }

        /// <summary>
        /// Gibt den zuletzt aktualisierten Status zurück, ob der PC gerade hochgefahren wurde.
        /// </summary>
        public static Task<bool> IsJustBootedAsync(TimeSpan threshold)
        {
            return Task.FromResult(_isJustBooted);
        }

        /// <summary>
        /// Gibt den aktuellen Shutdown-Status zurück.
        /// </summary>
        public static Task<bool> IsShuttingDownAsync()
        {
            return Task.FromResult(_isShuttingDown);
        }

        /// <summary>
        /// Gibt den aktuellen Ruhezustands-Status zurück.
        /// </summary>
        public static Task<bool> IsGoingToSleepAsync()
        {
            return Task.FromResult(_isGoingToSleep);
        }

        /// <summary>
        /// Gibt den zuletzt aktualisierten Status zurück, ob der Nutzer inaktiv ist.
        /// </summary>
        public static Task<bool> IsUserInactiveAsync(TimeSpan inactivityThreshold)
        {
            return Task.FromResult(_isUserInactive);
        }

        /// <summary>
        /// Gibt den zuletzt aktualisierten Status zurück, ob der PC nur wenig ausgelastet ist.
        /// </summary>
        public static Task<bool> IsPcLightlyLoadedAsync(float cpuUsageThreshold)
        {
            return Task.FromResult(_isPcLightlyLoaded);
        }

        /// <summary>
        /// Gibt den zuletzt aktualisierten Status zurück, ob bestimmte Programme offen sind.
        /// </summary>
        public static Task<bool> AreProgramsOpenAsync(string[] processNames)
        {
            return Task.FromResult(_areProgramsOpen);
        }

        #endregion

        /// <summary>
        /// Stoppt alle Hintergrund-Überwachungsschleifen.
        /// </summary>
        public static void StopMonitoring()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }
        }
    }
}
