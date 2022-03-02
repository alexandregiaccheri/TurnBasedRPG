using TurnBasedRPG.Entities;

Menu.Welcome();
int mainOption = Menu.MainMenu();

while (mainOption != 0)
{
    //Start Game
    if (mainOption == 1)
    {
        //Ask and confirms what character class to create
        int characterSelection = 0;
        bool confirmClass = false;
        while (confirmClass != true)
        {
            characterSelection = Menu.CharacterSelection();
            confirmClass = Menu.ConfirmClass(characterSelection);
        }

        //Ask if custom name is required and what name to use
        bool isNameRequired = Menu.IsNamingRequired();
        string characterName;
        if (isNameRequired == true) characterName = Menu.NameYourCharacter();
        else characterName = "Zodiark";

        //These variables will be used for both player and cpu characters
        int _hp = 0, _mp = 0, _str = 0, _agi = 0, _int = 0;

        switch (characterSelection)
        {
            //Warrior
            case 1:
                _hp = 500;
                _mp = 2;
                _str = 50;
                _agi = 15;
                _int = 15;
                break;

            //Rogue
            case 2:
                _hp = 500;
                _mp = 2;
                _str = 50;
                _agi = 15;
                _int = 15;
                break;

            //Wizard
            case 3:
                _hp = 500;
                _mp = 2;
                _str = 50;
                _agi = 15;
                _int = 15;
                break;
        }

        Hero hero = new Hero(characterName, _hp, _mp, _str, _agi, _int);

        //Define enemy and AI
        int _difficultyLevel = Menu.SelectDifficulty();
        int enemySelection = Menu.SelectEnemy();

        //Override variable values with the enemy ones
        switch (enemySelection)
        {
            //Skeleton Warrior
            case 1:
                characterName = "Skeleton Warrior";
                _hp = 500;
                _mp = 2;
                _str = 50;
                _agi = 15;
                _int = 15;
                break;

            //Skeleton Rogue
            case 2:
                characterName = "Skeleton Rogue";
                _hp = 500;
                _mp = 2;
                _str = 50;
                _agi = 15;
                _int = 15;
                break;

            //Skeleton Wizard
            case 3:
                characterName = "Skeleton Wizard";
                _hp = 500;
                _mp = 2;
                _str = 50;
                _agi = 15;
                _int = 15;
                break;

            //The Almighty Saru
            case 4:
                characterName = "The Almighty Saru";
                _hp = 999;
                _mp = 0;
                _str = 75;
                _agi = 0;
                _int = 0;
                break;
        }

        Enemy enemy = new Enemy(characterName, _hp, _mp, _str, _agi, _int, _difficultyLevel);

        Battle.BattleStart(hero, enemy);
    }
    mainOption = Menu.MainMenu();
}