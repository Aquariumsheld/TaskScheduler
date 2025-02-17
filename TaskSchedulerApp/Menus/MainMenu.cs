using FileDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Menus;

public class MainMenu : Menu
{
    private TaskScheduler Scheduler { get; set; }

    public MainMenu(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        Headline = "Hauptmenü";
        Options =
        [
            "[ neuen Task erstellen ]",
            "[ alle Tasks anzeigen ]",
            " ",
            "[ Voreinstellungen laden ]",
            "[ Einstellungen ]",
            " ",
            "[ Beenden ]"
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                var createTask = new CreateTaskMenu(Scheduler);
                createTask.Start();
                break;
            case 1:
                //todo Tasks anzeigen verknüpfen
                break;
            case 3:
                //todo Config laden verknüpfen
                break;
            case 4:
                var settings = new SettingsMenu();
                settings.Start();
                break;
            case 6:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
