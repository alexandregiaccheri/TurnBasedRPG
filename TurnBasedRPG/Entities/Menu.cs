using static System.Console;

namespace TurnBasedRPG.Entities
{
    internal static class Menu
    {
        public static void Welcome()
        {
            WriteLine("Welcome, Press ENTER to continue");
            ReadLine();
        }

        public static int MainMenu()
        {
            Clear();
            WriteLine("Select an option");
            WriteLine();
            WriteLine("1 - Begin Battle");
            WriteLine("2 - Help & Info");
            WriteLine("0 - Exit");
            WriteLine();
            Write("> ");

            int mainOption;

            try
            {
                mainOption = int.Parse(ReadLine());

                if (mainOption >= 0 && mainOption < 3) return mainOption;
                else throw new Exception();
            }
            catch
            {
                WriteLine();
                WriteLine("ERROR: Invalid option!");
                Write("Press ENTER to try again...");
                ReadLine();
                Clear();
                return MainMenu();
            }

        }

        public static int CharacterSelection()
        {
            Clear();
            WriteLine("Please select your character.");
            WriteLine();
            WriteLine("On the next screen you will be able to see");
            WriteLine("it's description and confirm your selection.");
            WriteLine();
            WriteLine("1 - Warrior");
            WriteLine("2 - Rogue");
            WriteLine("3 - Wizard");
            WriteLine();
            Write("> ");

            int characterSelection;

            try
            {
                characterSelection = int.Parse(ReadLine());
                if (characterSelection >= 0 && characterSelection < 4) return characterSelection;
                else throw new Exception();
            }
            catch
            {
                WriteLine();
                WriteLine("ERROR: Invalid option!");
                Write("Press ENTER to try again...");
                ReadLine();
                Clear();
                return CharacterSelection();
            }
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
                WriteLine();
                Write("> ");
                userInput = ReadLine();
            }
            if (userInput.ToUpper() == "Y") confirmed = true;
            return confirmed;
        }

        internal static bool ConfirmClass(int characterSelection)
        {
            if (characterSelection == 1) WarriorInfo();
            if (characterSelection == 2) RogueInfo();
            if (characterSelection == 3) WizardInfo();

            WriteLine();
            WriteLine("Confirm Selection? Y/N");
            WriteLine();
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
            WriteLine($"Is the name \"{characterName}\" ok? Y/N");
            WriteLine();
            Write("> ");
            bool confirmation = AskYesOrNo();
            if (confirmation == true) return characterName;
            else return NameYourCharacter();
        }

        internal static int SelectEnemy()
        {
            Clear();
            WriteLine("Please select your opponent:");
            WriteLine();
            WriteLine("1 - Skeleton Warrior");
            WriteLine("2 - Skeleton Rogue");
            WriteLine("3 - Skeleton Wizard");
            WriteLine("4 - Mighty Saru");
            WriteLine();
            Write("> ");

            int enemySelection;
            try
            {
                enemySelection = int.Parse(ReadLine());
                if (enemySelection >= 0 && enemySelection < 5) return enemySelection;
                else throw new Exception();
            }
            catch
            {
                WriteLine();
                WriteLine("ERROR: Invalid option!");
                Write("Press ENTER to try again...");
                ReadLine();
                Clear();
                return SelectEnemy();
            }
        }

        internal static int SelectDifficulty()
        {
            Clear();
            WriteLine("Please select an AI difficulty level:");
            WriteLine("1 - Easy");
            WriteLine("2 - Normal");
            WriteLine("3 - Hard");
            WriteLine();
            Write("> ");

            int difficulty = 0;


            try
            {
                difficulty = int.Parse(ReadLine());
                if (difficulty > 0 && difficulty < 4) return difficulty;
                else throw new Exception();
            }
            catch
            {
                WriteLine("Invalid option!");
                Write("Press ENTER to continue...");
                ReadLine();
                Clear();
                return SelectDifficulty();
            }
        }
    }
}