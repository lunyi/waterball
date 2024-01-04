namespace _4.Collision
{
    internal class Hero : Base
    {
        private int default_hp = 30;
        public int HP { get; set; }
        public Hero(int index) : base(index)
        {
            HP = default_hp;
            Key = 'H'; 
        }
        public void Add_HP()
        {
            HP = HP + 10;
        }

        public void Deduct_HP()
        {
            HP = HP - 10;
        }
    }
}