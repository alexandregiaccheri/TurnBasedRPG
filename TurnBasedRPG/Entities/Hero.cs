namespace TurnBasedRPG.Entities
{
    internal class Hero : BaseCharacter
    {
        public Hero(string _name, int _hp, int _mp, 
            int _str, int _agi, int _int)
        {
            this.Name = _name;
            this.HP = _hp;
            this.MP = _mp;
            this.Str = _str;
            this.Agi = _agi;
            this.Int = _int;
        }

        public void NameYourCharacter(string name)
        {
            this.Name = name;
        }
    }
}
