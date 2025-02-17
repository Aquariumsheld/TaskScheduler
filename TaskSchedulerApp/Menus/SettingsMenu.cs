using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TranslationsLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class SettingsMenu : Menu
{
    private string CurrentLanguage = GetCurrentLanguage();
    public SettingsMenu()
    {
        Headline = GetTranslation(CurrentLanguage, "headline_settingsmenu");
        Options =
        [
            GetTranslation(CurrentLanguage, "taskpreset_options_settingsmenu"),
            GetTranslation(CurrentLanguage, "language_options_settingsmenu"),
            " ",
            GetTranslation(CurrentLanguage, "back_options_settingsmenu")
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                //todo Config ändern verknüpfen
                break;
            case 1:
                ChangeLanguage();
                break;
            case 3:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
