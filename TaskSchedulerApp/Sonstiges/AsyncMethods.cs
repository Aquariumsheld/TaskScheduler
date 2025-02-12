using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.BackgroundClasses;

namespace TaskSchedulerApp.Sonstiges;

public static class AsyncMethods
{
    //public static void StartAsyncStatusTasks(TaskScheduler ts)
    //{
    //    Task.Run(PcStatus.PcStatusUpdate);
    //    Task.Run(ts.Start);
    //    Task.Run(async () =>
    //    {
    //        while (true)
    //        {
    //            // Rufe alle asynchronen Status-Abfragen parallel ab:
    //            Task<bool> justBootedTask = PcStatus.IsJustBootedAsync(TimeSpan.FromMinutes(5));
    //            Task<bool> shuttingDownTask = PcStatus.IsShuttingDownAsync();
    //            Task<bool> goingToSleepTask = PcStatus.IsGoingToSleepAsync();
    //            Task<bool> userInactiveTask = PcStatus.IsUserInactiveAsync(TimeSpan.FromSeconds(5));
    //            Task<bool> lightlyLoadedTask = PcStatus.IsPcLightlyLoadedAsync(20.0f);

    //            // Warte auf die Ergebnisse
    //            bool isJustBooted = await justBootedTask;
    //            bool isShuttingDown = await shuttingDownTask;
    //            bool isGoingToSleep = await goingToSleepTask;
    //            bool isUserInactive = await userInactiveTask;
    //            bool isPcLightlyLoaded = await lightlyLoadedTask;

    //            // Gib die aktuellen Statuswerte aus
    //            Console.Clear();
    //            Console.SetCursorPosition(0, 0);
    //            Console.WriteLine("---- PC-Status Update ----");
    //            Console.WriteLine($"JustBooted:     {isJustBooted}");
    //            Console.WriteLine($"ShuttingDown:   {isShuttingDown}");
    //            Console.WriteLine($"GoingToSleep:   {isGoingToSleep}");
    //            Console.WriteLine($"UserInactive:   {isUserInactive}");
    //            Console.WriteLine($"LightlyLoaded:  {isPcLightlyLoaded}");
    //            Console.WriteLine("--------------------------");

    //            // Warte 2 Sekunden bis zum nächsten Update
    //            //await Task.Delay(2000);
    //        }
    //    });
    //}
}
