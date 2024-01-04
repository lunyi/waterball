namespace _4.Collision
{
    internal class Hero : Base
    {
        private int default_hp = 30;
        public int HP { get; set; }
        public Hero(int index) : base(index)
        {
            HP = default_hp;
        }

        public override Char GetKey()
        {
            return 'H';
        }
    }
}