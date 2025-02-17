using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Menus;

public class SettingsMenu : Menu
{
    public SettingsMenu()
    {
        Headline = "Einstellungen";
        Options =
        [
            "[ Voreinstellungen für neue Tasks]",
            "[ Sprachen ]",
            " ",
            "[ zurück ]"
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
                //todo Sprache ändern
                break;
            case 3:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
