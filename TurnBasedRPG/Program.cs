using static System.Console;

WriteLine("Welcome, Press ENTER to continue");
ReadLine();
Clear();

int mainOption = 0;

while (mainOption != 3)
{
    WriteLine("Select an option");
    WriteLine();
    WriteLine("1 - Begin Battle");
    WriteLine("2 - Help");
    WriteLine("3 - Exit");
    WriteLine();
    Write("> ");
    
    try
    {
        mainOption = int.Parse(ReadLine());
        Clear();
    }
    catch
    {
        Clear();
        WriteLine("Please input a valid option!");
    }
    
    if (mainOption == 1)
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
        while (characterSelection == 0 || characterSelection != 4)
        {
            try
            {
                characterSelection = int.Parse(ReadLine());
            }
            catch
            {
                Clear();
                WriteLine("Please select a valid character option!");
                WriteLine("Please select your character.");
                WriteLine();
                WriteLine("On the next screen you will be able to see");
                WriteLine("it's statistics and confirm your selection.");
                WriteLine("1 - Warrior");
                WriteLine("2 - Rogue");
                WriteLine("3 - Wizard");
                WriteLine();
                Write("> ");
            }
            
            if (characterSelection == 1)
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
                do
                {
                    confirmSelection = ReadLine().ToUpper();
                } while (confirmSelection != "Y" || confirmSelection != "N");
            }

            if (characterSelection == 2)
            {

            }

            if (characterSelection == 3)
            {

            }
        }
        
    }

    if (mainOption == 2)
    {

    }
}
