using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using TaskClasses;

namespace TaskSchedulerApp.Menus;

class AutoTaskOptions : Menu
{
    private TaskScheduler Scheduler { get; set; }

    public AutoTaskOptions(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        Headline = "Automatische Tasks";
        Options =
        [
            "[ E-Mail ]",
            "[ Taschenrechner ]",
            "[ Browser ]",
            "[ Bildschirm-Sperre bei Inaktivität ]",
            " ",
            "[ zurück ]"
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                BasicTasks.Email(Scheduler);
                break;
            case 1:
                BasicTasks.Calculator(Scheduler);
                break;
            case 2:
                BasicTasks.Browser(Scheduler);
                break;
            case 3:
                int minutes = GetMinutes() * 1000000000 * 60;
                BasicTasks.LockInactive(Scheduler, minutes);
                break;
            case 5:
                break;
            default:
                break;
        }
    }

    static int GetMinutes()
    {
        int result = 0;

        do
        {
            string? input = Console.ReadLine();

            if (input != null) int.TryParse(input, out result);

        } while (result <= 0);

        return result;
    }
}
