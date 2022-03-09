namespace TurnBasedRPG.Classes
{
    internal abstract class BaseCharacter
    {
        internal string Name { get; set; }
        internal int HP { get; set; }
        internal int MP { get; set; }
        internal int Str { get; set; }
        internal int Agi { get; set; }
        internal int Int { get; set; }
        internal bool IsCharged { get; set; }
        internal bool IsDefending { get; set; }

        //Static random object to make sure that values won't repeat without having to deal with seeds
        protected static Random random = new Random();

        //Performs a random roll for critical attack, higher agi == higher chance
        internal bool CriticalCheck()
        {
            if (random.Next(1, 101) <= this.Agi) return true;
            else return false;
        }

        //Increases the next offensive action damage output, costs 1MP
        internal void Charge()
        {
            //Initiating this action also means that this entity is not defending anymore
            this.IsDefending = false;
            Console.Clear();

            if (this.MP > 0)
            {
                Console.WriteLine($"{this.Name} is charging a powerful attack...");
                Task.Delay(2500).Wait();
                this.IsCharged = true;
                this.MP--;
            }

            else
            {
                Console.WriteLine("You try to charge an attack... but you have no energy left...");
                Task.Delay(3000).Wait();
            }
        }

        //Drastically reduces the next incoming damage
        internal void Defend()
        {
            Console.Clear();
            Console.WriteLine($"{this.Name} is defending...");
            Task.Delay(2500).Wait();
            this.IsDefending = true;
        }

        internal void StopDefending()
        {
            this.IsDefending = false;
        }
    }
}