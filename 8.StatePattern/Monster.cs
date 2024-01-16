namespace _8.StatePattern
{
    internal class Monster
    {
        public int _x { get; private set; }
        public int _y { get; private set; }

        public Monster(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Move(int x, int y)
        {
            Clear(_x, _y);
            _x = x > _x ? _x+1 : _x-1;
            _y = y > _y ? _y+1 : _y-1;
            Display(_x, _y);
        }

        void Clear(int x, int y)
        {
            if (x <= 0 || y <= 0)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void Display(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("M");
        }
    }

    internal static class MonsterExtensios
    {
        public static void Move(this List<Monster> monsters,ref int x,ref int y)
        {
            for (int i = 0; i < monsters.Count; i++) 
            {
                monsters[i].Move(x, y);
            }
        }
        public static void Display(this List<Monster> monsters)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Display(monsters[i]._x, monsters[i]._y);
            }
        }
    }
}
