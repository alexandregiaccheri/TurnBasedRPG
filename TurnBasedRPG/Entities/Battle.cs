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
                    if (enemy.isDefending == true)
                        enemy.HP -= Convert.ToInt32(Convert.ToDouble(hero.Attack(enemy)) / 3.0);
                    else enemy.HP -= hero.Attack(enemy);
                    break;

                case 2:
                    if (enemy.isDefending == true)
                        enemy.HP -= Convert.ToInt32(Convert.ToDouble(hero.MagicAttack(enemy)) / 1.5);
                    else enemy.HP -= hero.MagicAttack(enemy);
                    break;

                case 3:
                    hero.Charge();
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
                    if (hero.isDefending == true)
                        hero.HP -= Convert.ToInt32(Convert.ToDouble(enemy.Attack(hero)) / 4.0);
                    else hero.HP -= enemy.Attack(hero);
                    break;

                case 2:
                    if (hero.isDefending == true)
                        hero.HP -= Convert.ToInt32(Convert.ToDouble(enemy.MagicAttack(hero)) / 2.0);
                    else hero.HP -= enemy.MagicAttack(hero);
                    break;

                case 3:
                    enemy.Charge();
                    break;

                case 4:
                    enemy.Defend();
                    break;
            }
        }

        internal static void DisplayStats(Hero hero, Enemy enemy)
        {
            WriteLine(">>>>>>>>>>>>>>>>>>>");
            WriteLine($"{hero.Name} - {hero.HP} HP / {hero.MP} MP");
            WriteLine(">>>>>>>>>>>>>>>>>>>");
            WriteLine($"{enemy.Name} - {enemy.HP} HP");
            WriteLine(">>>>>>>>>>>>>>>>>>>");
            WriteLine();
        }

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

            int playerInput = 0;
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

        internal static void BattleEnd(Hero hero, Enemy enemy)
        {
            if (hero.HP <= 0)
            {
                WriteLine($"You lose, {hero.Name} has been defeated...");
                WriteLine("Better luck next time :(");
                WriteLine();
                Write("Press ENTER to continue...");
                ReadLine();
            }
            if (enemy.HP <= 0)
            {
                WriteLine($"You won! {enemy.Name} has been defeated!");
                WriteLine("Congratulations!");
                WriteLine();
                Write("Press ENTER to continue...");
                ReadLine();
            }
        }
    }
}