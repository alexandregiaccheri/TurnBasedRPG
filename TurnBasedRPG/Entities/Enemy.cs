namespace TurnBasedRPG.Entities
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

        public int Decision { get; set; }

        /* Difficulty level should be:
         * 1 = easy
         * 2 = normal
         * 3 = hard */
        public int DifficultyLevel { get; set; }

        /* Decisions are based on difficulty and luck
         * Values are:
         * 1 - Attack
         * 2 - Magic Attack
         * 3 - Charge
         * 4 - Defend */
        public int DecideWhatToDo(Hero hero)
        {
            int diceRoll = random.Next(1, 101);
            if (this.isCharged == true)
            {
                if (this.Str > this.Int) return 1;
                else return 2;
            }

            if (hero.isCharged == true)
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
    }
}