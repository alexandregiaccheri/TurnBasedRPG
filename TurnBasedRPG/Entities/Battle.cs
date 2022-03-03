using static System.Console;

namespace TurnBasedRPG.Entities
{
    public static class Battle
    {
        //Battle loop
        internal static void BattleStart(Hero hero, Enemy enemy)
        {
            while (true)
            {
                Clear();
                DisplayStats(hero, enemy);

                int battleOption = BattleOption(hero, enemy);
                BattleAction(hero, enemy, battleOption);
                if (enemy.HP <= 0) break;

                int enemyAI = enemy.DecideWhatToDo(hero);
                BattleAction(enemy, hero, enemyAI);
                if (hero.HP <= 0) break;
            }

            BattleEnd(hero, enemy);
        }

        //Player turn
        internal static void BattleAction(Hero hero, Enemy enemy, int action)
        {
            switch (action)
            {
                case 1:
                    enemy.HP -= hero.Attack(enemy);
                    break;

                case 2:
                    enemy.HP -= hero.MagicAttack(enemy);
                    break;

                case 3:
                    hero.Charge();
                    hero.StopDefending();
                    break;

                case 4:
                    hero.Defend();
                    break;
            }
        }

        //CPU turn
        internal static void BattleAction(Enemy enemy, Hero hero, int action)
        {
            switch (action)
            {
                case 1:
                    hero.HP -= enemy.Attack(hero);
                    break;

                case 2:
                    hero.HP -= enemy.MagicAttack(hero);
                    break;

                case 3:
                    enemy.Charge();
                    enemy.StopDefending();
                    break;

                case 4:
                    enemy.Defend();
                    break;
            }
        }

        //Battle header with HP and MP
        internal static void DisplayStats(Hero hero, Enemy enemy)
        {
            WriteLine(">>>>>>>>>>>>>>>>>>>");
            WriteLine($"{hero.Name} - {hero.HP} HP / {hero.MP} MP");
            WriteLine(">>>>>>>>>>>>>>>>>>>");
            WriteLine($"{enemy.Name} - {enemy.HP} HP");
            WriteLine(">>>>>>>>>>>>>>>>>>>");
            WriteLine();
        }

        //Player turn battle menu
        internal static int BattleOption(Hero hero, Enemy enemy)
        {
            WriteLine();
            WriteLine("Your turn. Select an action:");
            WriteLine();
            WriteLine("1 - Attack");
            WriteLine("2 - Magic");
            WriteLine("3 - Charge");
            WriteLine("4 - Defend");
            WriteLine();
            Write("> ");

            int playerInput;
            do
            {
                try
                {
                    playerInput = int.Parse(ReadLine());
                }
                catch
                {
                    WriteLine("Invalid option!");
                    Write("Press ENTER to continue...");
                    ReadLine();
                    Clear();
                    DisplayStats(hero, enemy);
                    return BattleOption(hero, enemy);
                }
            } while ((playerInput < 1) || (playerInput > 4));

            return playerInput;
        }

        //When HP reaches zero
        internal static void BattleEnd(Hero hero, Enemy enemy)
        {
            if (hero.HP <= 0)
            {
                Clear();
                WriteLine($"{hero.Name} has been defeated...");
                WriteLine("Better luck next time!");
                WriteLine();
                Write("Press ENTER to continue...");
                ReadLine();
            }
            if (enemy.HP <= 0)
            {
                Clear();
                WriteLine($"{enemy.Name} has been defeated!");
                WriteLine("Congratulations!");
                WriteLine();
                Write("Press ENTER to continue...");
                ReadLine();
            }
        }
    }
}