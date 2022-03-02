namespace TurnBasedRPG.Entities
{
    internal abstract class BaseCharacter
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Str { get; set; }
        public int Agi { get; set; }
        public int Int { get; set; }
        public bool isCharged { get; set; }
        public bool isDefending { get; set; }

        public static Random random = new Random();

        private bool AgilityCheck()
        {
            if (random.Next(1, 101) < this.Agi) return true;
            else return false;
        }

        public int Attack(Enemy target)
        {
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}.");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}..");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}...");
            Task.Delay(1000).Wait();

            //Check if the attack missed
            if (AgilityCheck() == true)
            {
                Console.WriteLine($"{this.Name}'s attack missed!");
                if (this.isCharged == true) this.isCharged = false;
                return 0;
            }

            int damageRoll = random.Next(this.Str - 5, this.Str + 6);

            //Check if the attack was a critical hit
            if (AgilityCheck() == true)
            {
                Console.WriteLine("A critical hit!");
                Task.Delay(500).Wait();
                damageRoll = Convert.ToInt32(Convert.ToDouble(damageRoll) * 1.25);
            }

            if (this.isCharged == true)
            {
                damageRoll *= 3;
                this.isCharged = false;
            }

            Console.Write($"{this.Name}'s attack deals {damageRoll} damage!");
            Task.Delay(2500).Wait();
            return damageRoll;
        }

        public int Attack(Hero target)
        {
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}.");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}..");
            Task.Delay(500).Wait();
            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}...");
            Task.Delay(1000).Wait();

            //Check if the attack missed
            if (AgilityCheck() == true)
            {
                Console.WriteLine($"{this.Name}'s attack missed!");
                Task.Delay(2500).Wait();
                if (this.isCharged == true) this.isCharged = false;
                return 0;
            }

            int damageRoll = random.Next(this.Str - 5, this.Str + 6);

            //Check if the attack was a critical hit
            if (AgilityCheck() == true)
            {
                Console.WriteLine("A critical hit!");
                Task.Delay(500).Wait();
                damageRoll = Convert.ToInt32(Convert.ToDouble(damageRoll) * 1.25);
            }

            if (this.isCharged == true)
            {
                damageRoll *= 3;
                this.isCharged = false;
            }

            Console.Write($"{this.Name}'s attack deals {damageRoll} damage!");
            Task.Delay(2500).Wait();
            return damageRoll;
        }

        public int MagicAttack(Hero target)
        {
            int damageRoll = random.Next(this.Int, this.Int + 16);
            Console.WriteLine($"{this.Name}'s magic attack deals {damageRoll} damage!");
            return damageRoll;
        }

        public int MagicAttack(Enemy target)
        {
            int damageRoll = random.Next(this.Int, this.Int + 16);
            Console.WriteLine($"{this.Name}'s magic attack deals {damageRoll} damage!");
            return damageRoll;
        }

        public void Charge()
        {
            Console.Clear();
            Console.WriteLine($"{this.Name} begins channeling power...");
            Task.Delay(3000).Wait();
            this.isCharged = true;
        }

        public void Defend()
        {
            Console.Clear();
            Console.WriteLine($"{this.Name} is defending...");
            Task.Delay(3000).Wait();
            this.isDefending = true;
        }
    }
}