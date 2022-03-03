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
            WriteLine("############################");
            WriteLine("#       TurnBasedRPG       #");
            WriteLine("############################");
            WriteLine("# # #                  # # #");
            WriteLine("############################");
            WriteLine("#                          #");
            WriteLine("#     Select an option     #");
            WriteLine("#                          #");
            WriteLine("#     1 - Begin Battle     #");
            WriteLine("#     2 - Help/Info        #");
            WriteLine("#     0 - Exit             #");
            WriteLine("#                          #");
            WriteLine("############################");
            WriteLine("# # #                  # # #");
            WriteLine("############################");
            WriteLine("#      @alexandregiaccheri #");
            WriteLine("#                   2022   #");
            WriteLine("############################");
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
            WriteLine("###################################################");
            WriteLine("#           Please select your character          #");
            WriteLine("###################################################");
            WriteLine("#                                                 #");
            WriteLine("#    On the next screen you will be able to see   #");
            WriteLine("#   it's description and confirm your selection.  #");
            WriteLine("#                                                 #");
            WriteLine("#   1 - Warrior                                   #");
            WriteLine("#   2 - Rogue                                     #");
            WriteLine("#   3 - Wizard                                    #");
            WriteLine("#                                                 #");
            WriteLine("###################################################");
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
            WriteLine("####################################");
            WriteLine("#          The Warrior             #");
            WriteLine("####################################");
            WriteLine("#                                  #");
            WriteLine("#  Exiled from their homeland for  #");
            WriteLine("#  reasons better left behind,     #");
            WriteLine("#  the warrior boasts incredible   #");
            WriteLine("#  physical strength, resilience   #");
            WriteLine("#  and reflexes. While they truly  #");
            WriteLine("#  are masters of the martial arts,#");
            WriteLine("#  they aren't usually proficient  #");
            WriteLine("#  in the arcane ways.             #");
            WriteLine("#                                  #");
            WriteLine("####################################");
        }

        internal static void RogueInfo()
        {
            Clear();
            WriteLine("####################################");
            WriteLine("#            The Rogue             #");
            WriteLine("####################################");
            WriteLine("#                                  #");
            WriteLine("#  The dangerous, dark streets of  #");
            WriteLine("#  the kingdom's capital are the   #");
            WriteLine("#  perfect breeding grounds for    #");
            WriteLine("#  all sorts of evil, and in these #");
            WriteLine("#  fertile grounds the rogues work #");
            WriteLine("#  their magic. Agile, strong and  #");
            WriteLine("#  smart, these well balanced      #");
            WriteLine("#  individuals are versatile, but  #");
            WriteLine("#  aren't particularly great at    #");
            WriteLine("#  anything in special.            #");
            WriteLine("#                                  #");
            WriteLine("####################################");
        }

        internal static void WizardInfo()
        {
            Clear();
            WriteLine("####################################");
            WriteLine("#           The Wizard             #");
            WriteLine("####################################");
            WriteLine("#                                  #");
            WriteLine("#  This old wizard has spent most  #");
            WriteLine("#  of their life among the dusty   #");
            WriteLine("#  books, old tomes and yellow     #");
            WriteLine("#  parchments in the king's castle #");
            WriteLine("#  great library. They are fragile #");
            WriteLine("#  but quite quick and sharp.      #");
            WriteLine("#  While their combat capabilities #");
            WriteLine("#  can be somewhat limited due to  #");
            WriteLine("#  their lack of strength, they    #");
            WriteLine("#  surely have seen more danger    #");
            WriteLine("#  than most, and more importantly #");
            WriteLine("#  lived to tell the tale.         #");
            WriteLine("#                                  #");
            WriteLine("####################################");
        }

        internal static bool AskYesOrNo()
        {
            WriteLine();
            WriteLine("######################");
            WriteLine("# Confirm Selection? #");
            WriteLine("######################");
            WriteLine("#                    #");
            WriteLine("#    1 - Yes         #");
            WriteLine("#    2 - No          #");
            WriteLine("#                    #");
            WriteLine("######################");
            WriteLine();
            Write("> ");
            
            int userInput;
            try
            {
                userInput = int.Parse(ReadLine());

                if (userInput == 1) return true;
                else if (userInput == 2) return false;
                else throw new Exception();
            }
            catch
            {
                WriteLine();
                WriteLine("ERROR: Invalid option!");
                Write("Press ENTER to try again...");
                ReadLine();
                Clear();
                return AskYesOrNo();
            }
        }

        internal static bool ConfirmClass(int characterSelection)
        {
            if (characterSelection == 1) WarriorInfo();
            if (characterSelection == 2) RogueInfo();
            if (characterSelection == 3) WizardInfo();

            return AskYesOrNo();
        }

        internal static bool IsNamingRequired()
        {
            Clear();
            WriteLine("#########################################");
            WriteLine("#  Do you want to name your character?  #");
            WriteLine("#########################################");

            return AskYesOrNo();
        }

        internal static string NameYourCharacter()
        {
            WriteLine();
            Write("Please enter your character name > ");
            string characterName = ReadLine();

            WriteLine();
            WriteLine($"Is the name \"{characterName}\" ok? Y/N");

            bool confirmation = AskYesOrNo();
            if (confirmation == true) return characterName;
            else return NameYourCharacter();
        }

        internal static int SelectEnemy()
        {
            Clear();
            WriteLine("#################################");
            WriteLine("#  Please select your opponent  #");
            WriteLine("#################################");
            WriteLine("#                               #");
            WriteLine("#   1 - Asterius, the Brute     #");
            WriteLine("#   2 - Dolus, the Shadow       #");
            WriteLine("#   3 - Athena, the Wise        #");
            WriteLine("#   4 - Saru, the Almighty      #");
            WriteLine("#                               #");
            WriteLine("#################################");
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
            WriteLine("##########################################");
            WriteLine("#  Please select an AI difficulty level  #");
            WriteLine("##########################################");
            WriteLine("#                                        #");
            WriteLine("#    1 - Easy                            #");
            WriteLine("#    2 - Normal                          #");
            WriteLine("#    3 - Hard                            #");
            WriteLine("#                                        #");
            WriteLine("##########################################");
            WriteLine();
            Write("> ");

            int difficulty;
            try
            {
                difficulty = int.Parse(ReadLine());
                if (difficulty > 0 && difficulty < 4) return difficulty;
                else throw new Exception();
            }
            catch
            {
                WriteLine();
                WriteLine("Invalid option!");
                Write("Press ENTER to continue...");
                ReadLine();
                Clear();
                return SelectDifficulty();
            }
        }
    }
}