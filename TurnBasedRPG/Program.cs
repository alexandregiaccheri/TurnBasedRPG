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
                _mp = 3;
                _str = 50;
                _agi = 15;
                _int = 20;
                break;

            //Rogue
            case 2:
                _hp = 400;
                _mp = 5;
                _str = 40;
                _agi = 30;
                _int = 30;
                break;

            //Wizard
            case 3:
                _hp = 350;
                _mp = 15;
                _str = 20;
                _agi = 20;
                _int = 50;
                break;
        }

        Hero hero = new Hero(characterName, _hp, _mp, _str, _agi, _int);

        //Define enemy and AI
        int _difficultyLevel = Menu.SelectDifficulty();
        int enemySelection = Menu.SelectEnemy();

        //Override variable values with the enemy ones
        switch (enemySelection)
        {
            case 1:
                characterName = "Asterius";
                _hp = 500;
                _mp = 3;
                _str = 50;
                _agi = 15;
                _int = 20;
                break;
            
            case 2:
                characterName = "Dolus";
                _hp = 400;
                _mp = 5;
                _str = 40;
                _agi = 30;
                _int = 30;
                break;
            
            case 3:
                characterName = "Athena";
                _hp = 350;
                _mp = 15;
                _str = 20;
                _agi = 20;
                _int = 50;
                break;

            //The Almighty Saru
            case 4:
                characterName = "The Almighty Saru";
                _hp = 999;
                _mp = 0;
                _str = 75;
                _agi = 10;
                _int = 0;
                break;
        }

        Enemy enemy = new Enemy(characterName, _hp, _mp, _str, _agi, _int, _difficultyLevel);

        Battle.BattleStart(hero, enemy);
    }
    mainOption = Menu.MainMenu();
}