using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp;

public abstract class Menu
{
    protected string Headline { get; set; } = "";
    protected string[] Options { get; set; } = [];

    protected int ChoiceIndex { get; set; } = 0;

    protected bool KeepGoing { get; set; } = true;

    public virtual void Start()
    {
        while (KeepGoing)
        {
            GetChoice();

            Console.Clear();

            CallChoice();
        }
    }

    protected void GetChoice()
    {
        Console.Clear();

        ConsoleKey ck = ConsoleKey.None;

        do
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\n\n" + Headline + "\n------------------\n");

            #region Optionen ausgeben
            for (int i = 0; i < Options.Length; i++)
            {
                if (i == ChoiceIndex) Console.Write(" →  ");
                else Console.Write("     ");

                Console.WriteLine(Options[i] + "   ");
            }
            #endregion

            ck = Console.ReadKey(true).Key;

            switch (ck)
            {
                case ConsoleKey.W:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                    MoveDown();
                    break;
                default:
                    break;
            }

        } while (ck is not ConsoleKey.Enter);
    }

    protected void MoveUp()
    {
        if (ChoiceIndex == 0)
            ChoiceIndex = Options.Length - 1;

        else
            ChoiceIndex--;

        if (Options[ChoiceIndex] is " ")
            MoveUp();
    }

    protected void MoveDown()
    {
        if (ChoiceIndex == Options.Length - 1)
            ChoiceIndex = 0;

        else
            ChoiceIndex++;

        if (Options[ChoiceIndex] is " ")
            MoveDown();
    }

    protected abstract void CallChoice();
}
