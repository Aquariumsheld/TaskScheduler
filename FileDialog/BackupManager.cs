using System;
using System.IO;
using System.Windows.Forms;
using static TranslationsLibrary.TranslationManager;

namespace BackupTool
{
    public partial class Form1 : Form
    {
        private static string CurrentLanguage = GetCurrentLanguage();
        // Timer für geplante Backups (Windows.Forms.Timer für den UI-Thread)
        private System.Windows.Forms.Timer plannedTimer;
        // Timer für Debounce bei Echtzeit-Überwachung
        private System.Windows.Forms.Timer debounceTimer;
        // FileSystemWatcher für Echtzeit-Backups
        private FileSystemWatcher fileWatcher;
        // Flag, um parallele Backup-Ausführungen zu verhindern
        private bool isBackingUp = false;

        public Form1()
        {
            InitializeComponent();
            // Setze Standardauswahlen
            comboBoxBackupType.SelectedIndex = 0;
            comboBoxAutomation.SelectedIndex = 0;
            buttonStopAutomation.Enabled = false;
        }

        private void buttonBackupStart_Click(object sender, EventArgs e)
        {
            string sourceFolder = textBoxSourceFolder.Text;
            string destinationFolder = textBoxDestinationFolder.Text;
            string backupType = comboBoxBackupType.SelectedItem.ToString();
            string automationMethod = comboBoxAutomation.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(sourceFolder) || string.IsNullOrWhiteSpace(destinationFolder))
            {
                MessageBox.Show(GetTranslation(CurrentLanguage, "specify_source_destination_folder_button_backup_start_click_backupmanager"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (automationMethod == GetTranslation(CurrentLanguage, "manual_automationmethod_backupmanager"))
            {
                // Bei manueller Ausführung: Einfaches Backup
                PerformBackupSafe(sourceFolder, destinationFolder, backupType);
            }
            else if (automationMethod == GetTranslation(CurrentLanguage, "scheduled_automationmethod_backupmanager"))
            {
                // Timer starten, falls noch nicht aktiv
                if (plannedTimer == null)
                {
                    plannedTimer = new System.Windows.Forms.Timer();
                    plannedTimer.Interval = 60000; // Intervall: 60 Sekunden
                    plannedTimer.Tick += (s, args) => PerformBackupSafe(sourceFolder, destinationFolder, backupType);
                    plannedTimer.Start();
                    MessageBox.Show(GetTranslation(CurrentLanguage, "scheduled_started_automationmethod_backupmanager"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonBackupStart.Enabled = false;
                    buttonStopAutomation.Enabled = true;
                }
            }
            else if (automationMethod == GetTranslation(CurrentLanguage, "realtime_automationmethod_backupmanager"))
            {
                if (fileWatcher == null)
                {
                    if (plannedTimer == null)
                    {
                        plannedTimer = new System.Windows.Forms.Timer();
                        plannedTimer.Interval = 100; // Intervall: 60 Sekunden
                        plannedTimer.Tick += (s, args) => PerformBackupSafe(sourceFolder, destinationFolder, backupType);
                        plannedTimer.Start();
                    }
                    //fileWatcher.Changed += OnFileChanged;
                    //fileWatcher.Created += OnFileChanged;
                    //fileWatcher.Deleted += OnFileChanged;
                    //fileWatcher.Renamed += OnFileChanged;
                    //fileWatcher.EnableRaisingEvents = true;
                    MessageBox.Show(GetTranslation(CurrentLanguage, "realtime_started_automationmethod_backupmanager"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonBackupStart.Enabled = false;
                    buttonStopAutomation.Enabled = true;
                }
            }

        }

        /// <summary>
        /// Eventhandler für FileSystemWatcher-Änderungen (Echtzeit).
        /// Mithilfe eines Debounce-Timers wird sichergestellt, dass nicht zu häufig ein Backup angestoßen wird.
        /// </summary>
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (debounceTimer == null)
            {
                debounceTimer = new System.Windows.Forms.Timer();
                debounceTimer.Interval = 5000; // 5 Sekunden warten, bis sich die Ereignisse beruhigen
                debounceTimer.Tick += (s, args) =>
                {
                    debounceTimer.Stop();
                    string sourceFolder = textBoxSourceFolder.Text;
                    string destinationFolder = textBoxDestinationFolder.Text;
                    string backupType = comboBoxBackupType.SelectedItem.ToString();
                    PerformBackupSafe(sourceFolder, destinationFolder, backupType);
                };
            }
            debounceTimer.Stop();
            debounceTimer.Start();
        }


        /// <summary>
        /// Führt das Backup aus, sofern gerade keines läuft.
        /// </summary>
        private void PerformBackupSafe(string sourceFolder, string destinationFolder, string backupType)
        {
            if (isBackingUp)
                return; // Verhindere parallele Backups

            isBackingUp = true;
            try
            {
                BackupManager.PerformBackup(sourceFolder, destinationFolder, backupType);
                // Optional: Hier könnte man ein Log oder eine Statusanzeige aktualisieren.
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetTranslation(CurrentLanguage, "backupfailed_backupmanager") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isBackingUp = false;
            }
        }

        /// <summary>
        /// Stoppt aktuell aktive Automatisierungen (geplante und Echtzeit).
        /// </summary>
        private void buttonStopAutomation_Click(object sender, EventArgs e)
        {
            if (plannedTimer != null)
            {
                plannedTimer.Stop();
                plannedTimer.Dispose();
                plannedTimer = null;
            }
            if (fileWatcher != null)
            {
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
                fileWatcher = null;
            }
            MessageBox.Show(GetTranslation(CurrentLanguage, "automation_stopped_backupmanager"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buttonBackupStart.Enabled = true;
            buttonStopAutomation.Enabled = false;
        }

        /// <summary>
        /// Öffnet einen FolderBrowserDialog zur Auswahl des Quellordners.
        /// </summary>
        private void buttonBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = GetTranslation(CurrentLanguage, "choose_source_folder_backupmanager");
                // Optional: Startverzeichnis vorschlagen, falls bereits ein Pfad eingetragen ist
                if (!string.IsNullOrEmpty(textBoxSourceFolder.Text))
                    folderDialog.SelectedPath = textBoxSourceFolder.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxSourceFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Öffnet einen FolderBrowserDialog zur Auswahl des Zielordners.
        /// </summary>
        private void buttonBrowseDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = GetTranslation(CurrentLanguage, "choose_destination_folder_backupmanager");
                // Optional: Startverzeichnis vorschlagen
                if (!string.IsNullOrEmpty(textBoxDestinationFolder.Text))
                    folderDialog.SelectedPath = textBoxDestinationFolder.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestinationFolder.Text = folderDialog.SelectedPath;
                }
            }
        }
    }

    /// <summary>
    /// BackupManager enthält die Logik für die unterschiedlichen Backup-Methoden.
    /// </summary>
    public static class BackupManager
    {
        private static string CurrentLanguage = GetCurrentLanguage();
        // Dateiname für den Marker, der den Zeitpunkt des letzten Vollbackups speichert (für differenzielle Backups)
        private static string markerFileName = "fullBackupMarker.txt";
        public static void PerformBackup(string sourceFolder, string destinationFolder, string backupType)
        {
            if (!Directory.Exists(sourceFolder))
                throw new Exception("Quellordner existiert nicht.");

            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            GetTranslation(CurrentLanguage, "complete_backuptype_backupmanager");


            if (backupType == GetTranslation(CurrentLanguage, "complete_backuptype_backupmanager"))
                CopyAll(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else if (backupType == GetTranslation(CurrentLanguage, "incremental_backuptype_backupmanager"))
                CopyIncremental(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else if (backupType == GetTranslation(CurrentLanguage, "differential_backuptype_backupmanager"))
                CopyDifferential(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else if (backupType == GetTranslation(CurrentLanguage, "synchronize_backuptype_backupmanager"))
                Synchronize(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else
                throw new Exception(GetTranslation(CurrentLanguage, "unknown_backuptype_backupmanager"));
        }

        /// <summary>
        /// Führt ein Vollbackup durch (kopiert alle Dateien und Unterordner).
        /// </summary>
        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Kopiere alle Dateien
            foreach (FileInfo file in source.GetFiles())
            {
                string targetFilePath = Path.Combine(target.FullName, file.Name);
                file.CopyTo(targetFilePath, true);
            }
            // Kopiere alle Unterordner rekursiv
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyAll(subDir, nextTargetSubDir);
            }
        }

        /// <summary>
        /// Führt ein inkrementelles Backup durch: Nur Dateien, die neu oder geändert sind, werden kopiert.
        /// </summary>
        private static void CopyIncremental(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                string targetFilePath = Path.Combine(target.FullName, file.Name);
                if (!File.Exists(targetFilePath))
                {
                    file.CopyTo(targetFilePath, true);
                }
                else
                {
                    FileInfo targetFile = new FileInfo(targetFilePath);
                    if (file.LastWriteTime > targetFile.LastWriteTime)
                    {
                        file.CopyTo(targetFilePath, true);
                    }
                }
            }
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyIncremental(subDir, nextTargetSubDir);
            }
        }

        /// <summary>
        /// Führt ein differenzielles Backup durch:
        /// Falls kein Marker vorhanden ist, wird ein Vollbackup erstellt und der Marker gesetzt.
        /// Andernfalls werden nur Dateien kopiert, die seit dem Marker-Zeitpunkt geändert wurden.
        /// </summary>
        private static void CopyDifferential(DirectoryInfo source, DirectoryInfo target)
        {
            string markerPath = Path.Combine(target.FullName, markerFileName);
            DateTime fullBackupTime;

            if (!File.Exists(markerPath))
            {
                // Kein Marker vorhanden: Vollbackup ausführen und Marker setzen
                CopyAll(source, target);
                fullBackupTime = DateTime.Now;
                File.WriteAllText(markerPath, fullBackupTime.ToString("o")); // ISO 8601 Format
            }
            else
            {
                // Marker existiert: Lese den Zeitpunkt des letzten Vollbackups
                string markerContent = File.ReadAllText(markerPath);
                if (!DateTime.TryParse(markerContent, null, System.Globalization.DateTimeStyles.RoundtripKind, out fullBackupTime))
                {
                    // Bei ungültigem Marker, Vollbackup ausführen und Marker setzen
                    CopyAll(source, target);
                    fullBackupTime = DateTime.Now;
                    File.WriteAllText(markerPath, fullBackupTime.ToString("o"));
                    return;
                }
                // Kopiere nur Dateien, die seit dem Marker-Zeitpunkt geändert wurden
                CopyDifferentialRecursive(source, target, fullBackupTime);
            }
        }

        /// <summary>
        /// Rekursive Methode für differenzielles Backup (kopiert nur geänderte Dateien).
        /// </summary>
        private static void CopyDifferentialRecursive(DirectoryInfo source, DirectoryInfo target, DateTime fullBackupTime)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                if (file.LastWriteTime > fullBackupTime)
                {
                    string targetFilePath = Path.Combine(target.FullName, file.Name);
                    file.CopyTo(targetFilePath, true);
                }
            }
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyDifferentialRecursive(subDir, nextTargetSubDir, fullBackupTime);
            }
        }

        /// <summary>
        /// Synchronisiert den Zielordner mit dem Quellordner:
        /// - Neue oder aktualisierte Dateien werden kopiert.
        /// - Dateien, die im Quellordner gelöscht wurden, werden auch im Zielordner entfernt.
        /// - Unterordner werden rekursiv synchronisiert.
        /// </summary>
        private static void Synchronize(DirectoryInfo source, DirectoryInfo target)
        {
            // Zielverzeichnis erstellen, falls nicht vorhanden.
            if (!target.Exists)
                target.Create();

            // 1. Dateien und Unterordner aus Quellordner kopieren oder aktualisieren.
            foreach (FileInfo sourceFile in source.GetFiles())
            {
                string targetFilePath = Path.Combine(target.FullName, sourceFile.Name);
                if (!File.Exists(targetFilePath))
                {
                    sourceFile.CopyTo(targetFilePath, true);
                }
                else
                {
                    FileInfo targetFile = new FileInfo(targetFilePath);
                    if (sourceFile.LastWriteTime > targetFile.LastWriteTime)
                    {
                        sourceFile.CopyTo(targetFilePath, true);
                    }
                }
            }

            foreach (DirectoryInfo sourceSubDir in source.GetDirectories())
            {
                string targetSubDirPath = Path.Combine(target.FullName, sourceSubDir.Name);
                DirectoryInfo targetSubDir = new DirectoryInfo(targetSubDirPath);
                // Rekursiv synchronisieren
                Synchronize(sourceSubDir, targetSubDir);
            }

            // 2. Dateien im Ziel löschen, die nicht mehr im Quellordner existieren.
            foreach (FileInfo targetFile in target.GetFiles())
            {
                string sourceFilePath = Path.Combine(source.FullName, targetFile.Name);
                if (!File.Exists(sourceFilePath))
                {
                    targetFile.Delete();
                }
            }

            // 3. Unterordner im Ziel löschen, die nicht mehr im Quellordner vorhanden sind.
            foreach (DirectoryInfo targetSubDir in target.GetDirectories())
            {
                string sourceSubDirPath = Path.Combine(source.FullName, targetSubDir.Name);
                if (!Directory.Exists(sourceSubDirPath))
                {
                    targetSubDir.Delete(true);
                }
            }
        }
    }
}
