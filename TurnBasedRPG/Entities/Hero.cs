using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPG.Entities
{
    internal class Hero : BaseCharacter
    {
        public bool isDefending { get; set; }
        
        void defend()
        {
            this.isDefending = true;
        }
    }
}
