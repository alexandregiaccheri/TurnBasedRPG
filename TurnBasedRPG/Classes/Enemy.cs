namespace TurnBasedRPG.Classes
{
    internal class Enemy : BaseCharacter
    {
        public Enemy(string _name, int _hp, int _mp,
            int _str, int _agi, int _int, int _difficulty)
        {
            this.Name = _name;
            this.HP = _hp;
            this.MP = _mp;
            this.Str = _str;
            this.Agi = _agi;
            this.Int = _int;
            this.DifficultyLevel = _difficulty;
        }

        /* Difficulty level should be:
         * 1 = easy
         * 2 = normal
         * 3 = hard */
        internal int DifficultyLevel { get; set; }

        /* Decisions are based on difficulty and luck
         * Values are:
         * 1 - Attack
         * 2 - Magic Attack
         * 3 - Charge
         * 4 - Defend */
        internal int DecideWhatToDo(Hero hero)
        {
            int diceRoll = random.Next(1, 101);
            if (this.IsCharged == true)
            {
                if (this.Str > this.Int && this.MP > 0) return 1;
                else return 2;
            }

            if (hero.IsCharged == true)
            {
                int totalRoll = diceRoll - (25 * this.DifficultyLevel);
                if (totalRoll >= 0) return 4;
            }

            switch (this.DifficultyLevel)
            {
                case 1:
                    diceRoll = random.Next(1, 11);
                    if ((diceRoll >= 9) && (this.MP > 0)) return 3;
                    else
                    {
                        diceRoll = random.Next(1, 11);
                        if (diceRoll > 5) return 1;
                        else return 2;
                    }

                case 2:
                    diceRoll = random.Next(1, 11);
                    if ((diceRoll > 5) && (this.MP > 0)) return 3;
                    else
                    {
                        if (this.Str > this.Int) return 1;
                        else return 2;
                    }

                case 3:
                    diceRoll = random.Next(1, 11);
                    if ((diceRoll > 3) && (this.MP > 0)) return 3;
                    else
                    {
                        if (this.Str > this.Int) return 1;
                        else return 2;
                    }
            }

            return 0;
        }

        //Check for evasion, higher agi == higher chance to evade
        internal bool DodgeCheck(Hero target)
        {
            if (random.Next(1, 101) < (target.Agi / 2)) return true;
            else return false;
        }

        //Attack using the Str attribute
        internal int Attack(Hero target)
        {
            //Initiating an attack also means that this entity is not defending anymore
            this.IsDefending = false;

            Console.Clear();
            Console.WriteLine($"{this.Name} attacks {target.Name}...");
            Task.Delay(1000).Wait();

            //Check if the opponent dodged
            if (DodgeCheck(target) == true)
            {
                Console.WriteLine($"{target.Name} dodged!");
                Task.Delay(2000).Wait();

                //Deals no damage and loses charged state
                if (this.IsCharged == true) this.IsCharged = false;
                return 0;
            }

            int damageRoll = random.Next(this.Str - 5, this.Str + 6);

            //Check if the attack was a critical hit
            bool isThisACritical = CriticalCheck();
            if (isThisACritical == true)
            {
                Console.WriteLine("A critical hit!");
                Task.Delay(500).Wait();

                damageRoll *= (this.Agi / 5);
            }

            //Check if it was a charged attack and changes charged to false
            if (this.IsCharged == true)
            {
                if (isThisACritical == true)
                {
                    damageRoll = Convert.ToInt32(Convert.ToDouble(damageRoll * 1.2));
                    this.IsCharged = false;
                }
                else
                {
                    damageRoll *= 3;
                    this.IsCharged = false;
                }
            }

            //Check if the target is defending to mitigate damage
            if (target.IsDefending == true)
            {
                damageRoll /= 5;
                target.IsDefending = false;
            }

            Console.Write($"{this.Name} hits {target.Name} for {damageRoll} damage!");
            Task.Delay(2500).Wait();

            return damageRoll;
        }

        //Attack using the Int attribute
        internal int MagicAttack(Hero target)
        {
            //Initiating a magic attack also means that this entity is not defending anymore
            this.IsDefending = false;

            Console.Clear();
            Console.WriteLine($"{this.Name} casts a powerful spell upon {target.Name}...");
            Task.Delay(1000).Wait();

            //Check if the opponent dodged
            if (DodgeCheck(target) == true)
            {
                Console.WriteLine($"{target.Name} dodged!");
                Task.Delay(2000).Wait();

                //Deals no damage and loses charged state
                if (this.IsCharged == true) this.IsCharged = false;
                return 0;
            }

            int damageRoll = random.Next(this.Int, this.Int + 16);

            //Check if it was a charged attack and changes charged to false
            if (this.IsCharged == true)
            {
                damageRoll *= 3;
                this.IsCharged = false;
            }

            //Check if the target is defending to mitigate damage
            if (target.IsDefending == true)
            {
                damageRoll /= 3;
                target.IsDefending = false;
            }

            Console.WriteLine($"{this.Name}'s spell hits {target.Name} for {damageRoll} damage!");
            Task.Delay(2500).Wait();

            this.MP--;
            return damageRoll;
        }
    }
}