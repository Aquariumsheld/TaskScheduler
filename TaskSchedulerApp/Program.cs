using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskSchedulerApp.BackgroundClasses;
using FileDialog;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Forms;
using ShutdownBlocker;
using TaskSchedulerApp;
using TaskSchedulerApp.Menus;

public class Program
{
    [STAThread]
    public static void Main()
    {
        var taskScheduler = new TaskScheduler();

        var mainMenu = new MainMenu(taskScheduler);
        mainMenu.Start();
    }

    //public static async Task PreventShutdownStart()
    //{
    //    System.Windows.Forms.Application.Run(new PreventShutdown());
    //}

    public static async Task StartAsyncStatusTasks(TaskScheduler taskScheduler)
    {
        //_ = Task.Run(PreventShutdownStart);
        _ = Task.Run(PcStatus.PcStatusUpdate);
    }
}

public static class SystemControl
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool LockWorkStation();
}


