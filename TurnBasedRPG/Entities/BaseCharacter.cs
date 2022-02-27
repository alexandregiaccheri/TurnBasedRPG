using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static Random random = new Random();

        int Attack()
        {
            int damage = random.Next(this.Str - 2, this.Str + 3) + random.Next(5);
            int checkCrit = random.Next(1, 101);
            int checkMiss = random.Next(1, 101);
            if (checkMiss >= 20 - this.Agi)
            {
                if (checkCrit >= 95 - this.Agi)
                {
                    return damage * 2;
                }
                return damage;
            }            
            return 0;
        }

        int MagicAttack()
        {
            int damage = random.Next(this.Int - 2, this.Int + 3) + random.Next(5, 10);
            return damage;
        }
    }
}
