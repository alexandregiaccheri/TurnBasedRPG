using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPG.Entities
{
    internal class Enemy : BaseCharacter
    {
        public int decision { get; set; }
        public bool isCharged { get; set; }

        void Charge()
        {
            this.isCharged = true;
        }
    }
}
