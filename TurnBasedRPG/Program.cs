using TurnBasedRPG.Entities;

//welcome message
Menu.Welcome();

//main menu and selection
int mainOption = Menu.MainMenu();

//program running
while (mainOption != 0)
{
    //Begin Battle
    if (mainOption == 1)
    {
        int characterSelection;
        bool confirmClass;
        
        //Ask and confirms what character class to create
        do
        {
            characterSelection = Menu.CharacterSelection();
            confirmClass = Menu.ConfirmClass(characterSelection);
        } while (confirmClass != true);
        
        //Ask if custom name is required
        bool isNameRequired = Menu.IsNamingRequired();
        string characterName;

        //If decided to use custom name
        if (isNameRequired == true)
        {
            characterName = Menu.NameYourCharacter();
        }

        //If decided to use default name
        else
        {
            characterName = "You";
        }

        Hero hero = new Hero();
        
        //Create Warrior
        if (characterSelection == 1)
        {
            hero.Name = characterName;
            hero.HP = 150;
            hero.MP = 2;
            hero.Str = 8;
            hero.Agi = 5;
            hero.Int = 2;
        }

        //Create Rogue
        else if (characterSelection == 2)
        {
            hero.Name = characterName;
            hero.HP = 110;
            hero.MP = 5;
            hero.Str = 5;
            hero.Agi = 11;
            hero.Int = 2;
        }

        //Create Wizard
        else
        {
            hero.Name = characterName;
            hero.HP = 80;
            hero.MP = 8;
            hero.Str = 2;
            hero.Agi = 5;
            hero.Int = 8;
        }

        //dummy enemy
        Enemy enemy = new Enemy
        {
            Name = "Bichinho",
            HP = 180,
            MP = 5,
            Str = 5,
            Agi = 2,
            Int = 2
        };

        while (hero.HP > 0 && enemy.HP > 0)
        {
            Console.Clear();
            int damage;
            damage = enemy.Attack();
            hero.HP -= damage;

            if (hero.HP <= 0)
            {
                Console.WriteLine($"{hero.Name} has been defeated!");
                Console.ReadLine();
                break;
            }
            Console.WriteLine($"{enemy.Name} hits {hero.Name} for {damage} HP!");
            Console.WriteLine($"{hero.Name} HP is now {hero.HP}");
            Console.ReadLine();

            damage = hero.Attack();
            enemy.HP -= damage;

            if (enemy.HP <= 0)
            {
                Console.WriteLine($"{enemy.Name} has been defeated!");
                Console.ReadLine();
                break;
            }
            Console.WriteLine($"{hero.Name} hits {enemy.Name} for {damage} HP!");
            Console.WriteLine($"{enemy.Name} HP is now {enemy.HP}");
            Console.ReadLine();


        }
        
    }
    mainOption = Menu.MainMenu();
}