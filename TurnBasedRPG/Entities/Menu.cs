using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TurnBasedRPG.Entities
{
    internal static class Menu
    {
        public static void Welcome()
        {
            WriteLine("Welcome, Press ENTER to continue");
            ReadLine();
            Clear();
        }
        public static int MainMenu()
        {
            WriteLine("Select an option");
            WriteLine();
            WriteLine("1 - Begin Battle");
            WriteLine("2 - Help");
            WriteLine("3 - Exit");
            WriteLine();
            Write("> ");

            int mainOption = 0;
            do
            {
                try
                {
                    mainOption = int.Parse(ReadLine());
                    Clear();
                }
                catch
                {
                    Clear();
                    WriteLine("Please input a valid option!");
                    return MainMenu();
                }
                if (mainOption == 3) break;
            } while (mainOption < 0 || mainOption > 3);


            return mainOption;
        }
        public static int CharacterSelection()
        {
            WriteLine("Please select your character.");
            WriteLine();
            WriteLine("On the next screen you will be able to see");
            WriteLine("it's statistics and confirm your selection.");
            WriteLine("1 - Warrior");
            WriteLine("2 - Rogue");
            WriteLine("3 - Wizard");
            WriteLine();
            Write("> ");

            int characterSelection = 0;
            do
            {
                try
                {
                    characterSelection = int.Parse(ReadLine());
                }
                catch
                {
                    Clear();
                    return CharacterSelection();
                }
            } while (characterSelection < 0 || characterSelection > 3);

            return characterSelection;
        }
        internal static void ConfirmClass(int characterSelection)
        {
            if (characterSelection == 1) ConfirmWarrior();
            if (characterSelection == 2) ConfirmWarrior();
            if (characterSelection == 3) ConfirmWarrior();
        }
        public static bool ConfirmWarrior()
        {
            Clear();
            WriteLine("Warrior");
            WriteLine();
            WriteLine("High Strength");
            WriteLine("Medium Agility");
            WriteLine("Low Inteligence");
            WriteLine();
            WriteLine("High HP");
            WriteLine("Low MP");
            WriteLine();
            WriteLine("Confirm Selection? Y/N");
            Write("> ");

            string confirmSelection;
            confirmSelection = ReadLine();

            if (confirmSelection.ToUpper() == "Y") return true;
            else return false;
        }
    }
}