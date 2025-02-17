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
using MiNET.Utils;
using BackupTool;

public class Program
{
    [STAThread]
    public static void Main()
    {
        Console.CursorVisible = false;

        var taskScheduler = new TaskScheduler();

        var mainMenu = new MainMenu(taskScheduler);
        mainMenu.Start();
        Task.Run(() => PcStatus.StartMonitoring(TimeSpan.FromMinutes(3), TimeSpan.FromMinutes(3), 20.0f,["test"], "test" ));
    }

    //public static async Task PreventShutdownStart()
    //{
    //    System.Windows.Forms.Application.Run(new PreventShutdown());
    //}
}

public static class SystemControl
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool LockWorkStation();
}


