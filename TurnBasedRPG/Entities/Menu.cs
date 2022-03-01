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
            WriteLine("0 - Exit");
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
        internal static void WarriorInfo()
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
        }
        internal static void RogueInfo()
        {
            Clear();
            WriteLine("Rogue");
            WriteLine();
            WriteLine("Medium Strength");
            WriteLine("High Agility");
            WriteLine("Low Inteligence");
            WriteLine();
            WriteLine("Medium HP");
            WriteLine("Medium MP");
        }
        internal static void WizardInfo()
        {
            Clear();
            WriteLine("Wizard");
            WriteLine();
            WriteLine("Low Strength");
            WriteLine("Medium Agility");
            WriteLine("High Inteligence");
            WriteLine();
            WriteLine("Low HP");
            WriteLine("High MP");
        }
        internal static bool AskYesOrNo()
        {
            string userInput = ReadLine();
            bool confirmed = false;
            while (userInput.ToUpper() != "Y" && userInput.ToUpper() != "N")
            {
                Clear();
                WriteLine("Please respond with Y or N!");
                Write("> ");
                userInput = ReadLine();
            }
            if (userInput.ToUpper() == "Y") confirmed = true;
            if (userInput.ToUpper() == "N") confirmed = false;
            return confirmed;
        }
        internal static bool ConfirmClass(int characterSelection)
        {
            if (characterSelection == 1) WarriorInfo();
            if (characterSelection == 2) RogueInfo();
            if (characterSelection == 3) WizardInfo();
            
            WriteLine();
            WriteLine("Confirm Selection? Y/N");
            Write("> ");
            
            return AskYesOrNo();
        }
        internal static bool IsNamingRequired()
        {
            Clear();
            WriteLine("Do you want to name your character? Y/N");
            WriteLine();
            Write("> ");

            return AskYesOrNo();
        }
        internal static string NameYourCharacter()
        {
            Clear();
            Write("Please enter your character name: ");
            string characterName = ReadLine();

            Clear();
            WriteLine($"Is this name \"{characterName}\" ok?");
            bool confirmation = AskYesOrNo();
            if (confirmation == true) return characterName;
            else return NameYourCharacter();
        }
    }
}