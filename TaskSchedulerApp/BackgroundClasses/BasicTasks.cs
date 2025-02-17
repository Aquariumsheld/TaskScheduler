using System.Diagnostics;
using System.Windows;
using TaskSchedulerApp.BackgroundClasses;
using TaskClasses;

public class BasicTasks
{
    public static void Email(TaskScheduler taskScheduler)
    {
        var notificationManager = new NotificationManager();
        var logger = new Logger("task_logs.csv");

        var OpenEmail = new PreTask("OpenMail", () =>
        {
            notificationManager.SendNotification("OpenMail executed.");
            logger.Log("OpenMail", "Task successfully executed.");
            string email = "empfaenger@example.com";
            string subject = Uri.EscapeDataString("Betreff der E-Mail");
            string body = Uri.EscapeDataString("Hallo,\n\nDas ist eine vorgefertigte Nachricht.");

            string mailto = $"mailto:{email}?subject={subject}&body={body}";

            try
            {
                Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Öffnen des E-Mail-Clients: " + ex.Message);
            }

        }, DateTime.Now.AddSeconds(5), priority: 1);

        taskScheduler.ScheduleTask(OpenEmail);
    }

    public static void Calculator(TaskScheduler taskScheduler)
    {
        var notificationManager = new NotificationManager();
        var logger = new Logger("task_logs.csv");

        var Calculator = new PreTask("Calculator", () =>
        {
            notificationManager.SendNotification("Calculator executed.");
            logger.Log("Calculator", "Task successfully executed.");
            try
            {
                Process.Start(new ProcessStartInfo("calc.exe") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Öffnen des Taschenrechners: " + ex.Message);
            }

        }, DateTime.Now.AddSeconds(5), priority: 1);

        taskScheduler.ScheduleTask(Calculator);
    }

    public static void Browser(TaskScheduler taskScheduler)
    {
        var notificationManager = new NotificationManager();
        var logger = new Logger("task_logs.csv");

        var Browser = new PreTask("Browser", () =>
        {
            notificationManager.SendNotification("Browser executed.");
            logger.Log("Browser", "Task successfully executed.");
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.google.com",
                UseShellExecute = true
            };
            Process.Start(psi);

        }, DateTime.Now.AddSeconds(5), priority: 1);

        taskScheduler.ScheduleTask(Browser);
    }

    public static void LockInactive(TaskScheduler taskScheduler, int timeSpan)
    {
        var notificationManager = new NotificationManager();
        var logger = new Logger("task_logs.csv");

        var LockInactive = new PreTask("LockInactive", () =>
        {
            notificationManager.SendNotification("LockInactive executed.");
            logger.Log("LockInactive", "Task successfully executed.");
            Task.Run(async () =>
            {
                while (true)
                {
                    // Asynchrone Prüfung, ob der Nutzer mindestens 1 Minute inaktiv ist
                    bool inactive = PcStatus.IsUserInactive;
                    if (inactive)
                    {
                        notificationManager.SendNotification("Nutzer inaktiv: PC wird gesperrt.");
                        logger.Log("LockPC", "Nutzer inaktiv. PC wird sofort gesperrt.");
                        SystemControl.LockWorkStation();
                        break; // Nach dem Sperren beenden wir die Überwachungsschleife.
                    }
                    // Überprüfe alle 5 Sekunden erneut
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            });

        }, DateTime.Now.AddSeconds(5), priority: 1);

        taskScheduler.ScheduleTask(LockInactive);
    }


}