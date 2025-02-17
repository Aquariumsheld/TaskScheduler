using System.Diagnostics;
using System.Windows;
using TaskSchedulerApp.BackgroundClasses;
using TranslationsLibrary;
using static TranslationsLibrary.TranslationManager;

public class BasicTasks
{
    private static string CurrentLanguage = GetCurrentLanguage();
    public static void Email(TaskScheduler taskScheduler)
    {
        var notificationManager = new NotificationManager();
        var logger = new Logger("task_logs.csv");

        var OpenEmail = new PreTask("OpenMail", () =>
        {
            notificationManager.SendNotification("openmail_executed_mail_basictasks");
            logger.Log("OpenMail", "Task successfully executed.");
            string email = GetTranslation(CurrentLanguage, "reciever_mail_basictasks");
            string subject = Uri.EscapeDataString(GetTranslation(CurrentLanguage, "subject_mail_basictasks").ToString());
            string body = Uri.EscapeDataString(GetTranslation(CurrentLanguage, "text_mail_basictasks").ToString());

            string mailto = $"mailto:{email}?subject={subject}&body={body}";

            try
            {
                Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetTranslation(CurrentLanguage, "openmail_error_executed_mail_basictasks") + ex.Message);
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
            notificationManager.SendNotification("opencalc_executed_calculator_basictasks");
            logger.Log("Calculator", "Task successfully executed.");
            try
            {
                Process.Start(new ProcessStartInfo("calc.exe") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetTranslation(CurrentLanguage, "opencalc_error_executed_calculator_basictasks") + ex.Message);
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
            notificationManager.SendNotification("openbrowser_executed_browser_basictasks");
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
            notificationManager.SendNotification("lockinactive_basictasks");
            logger.Log("LockInactive", "Task successfully executed.");
            Task.Run(async () =>
            {
                while (true)
                {
                    // Asynchrone Prüfung, ob der Nutzer mindestens 1 Minute inaktiv ist
                    bool inactive = PcStatus.IsUserInactive;
                    if (inactive)
                    {
                        notificationManager.SendNotification("lockinactive_basictasks");
                        logger.Log("LockPC", "User inactive. Pc is locked");
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