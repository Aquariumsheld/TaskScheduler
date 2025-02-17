using FileDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace TaskSchedulerApp.Menus;

class CreateTaskMenu : Menu
{
    private TaskScheduler Scheduler { get; set; }

    public CreateTaskMenu(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        Headline = "Task erstellen";
        Options =
        [
            "[ individueller Task ]",
            "[ automatischer Task ]",
            "[ Backup-Task ]",
            " ",
            "[ zurück ]"
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                var creator = new TaskCreator(Scheduler);
                System.Windows.Forms.Application.Run(creator);
                break;
            case 1:
                var autoCreator = new AutoTaskOptions(Scheduler);
                autoCreator.Start();
                break;
            case 2:
                //todo Funktion verknüpfen
                break;
            case 4:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
