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

        //Static random to make sure values won't repeat without having to deal with seeds
        protected static Random random = new Random();

        //Performs a random roll for critical attack, higher agi == higher chance
        protected bool CriticalCheck()
        {
            if (random.Next(1, 101) < this.Agi) return true;
            else return false;
        }

        //Performs a charge, increasing the next offensive action damage output
        public void Charge()
        {
            //Initiating a charge also means that this entity is not defending anymore
            this.isDefending = false;
            Console.Clear();

            if (this.MP > 0)
            {
                Console.WriteLine($"{this.Name} is charging a powerful attack...");
                Task.Delay(2500).Wait();
                this.isCharged = true;
                this.MP--;
            }

            else
            {
                Console.WriteLine("You try to charge an attack, but you have no energy left...");
                Task.Delay(3000).Wait();
            }
        }

        //Sets defending to true, drastically reducing incoming damage for the turn
        public void Defend()
        {
            Console.Clear();
            Console.WriteLine($"{this.Name} is defending...");
            Task.Delay(2500).Wait();
            this.isDefending = true;
        }

        public void StopDefending()
        {
            this.isDefending = false;
        }
    }
}