using FileDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TranslationsLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class MainMenu : Menu
{
    private string CurrentLanguage = GetCurrentLanguage();
    private TaskScheduler TaskScheduler { get; set; }

    public MainMenu(TaskScheduler taskScheduler)
    {
        TaskScheduler = taskScheduler;

        Headline = GetTranslation(CurrentLanguage, "headline_mainmenu");
        Options =
        [
            GetTranslation(CurrentLanguage, "newtask_options_mainmenu"),
            GetTranslation(CurrentLanguage, "showtask_options_mainmenu"),
            " ",
            GetTranslation(CurrentLanguage, "loadpreset_options_mainmenu"),
            GetTranslation(CurrentLanguage, "settings_options_mainmenu"),
            " ",
            GetTranslation(CurrentLanguage, "end_options_mainmenu")
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                System.Windows.Forms.Application.Run(new TaskCreator());
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
