namespace _8.StatePattern
{
    internal class Monster
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private State _state;
        public Monster(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void EnterState(State state)
        { 
            _state = state;
        }

        public void MoveX(int x, int y)
        {
            Clear(X, Y);
            X = x > X ? X+1 : X-1;
            Display(X, Y);
        }

        public void MoveY(int x, int y)
        {
            Clear(X, Y);
            Y = y > Y ? Y + 1 : Y - 1;
            Display(X, Y);
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

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void Display(int x, int y)
        {
            if (x <= 0 || y <= 0 || x > Console.BufferWidth || y > Console.BufferHeight)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine("M");
        }
    }

    internal static class MonsterExtensios
    {
        private static Random random = new Random();
        public static void Move(this List<Monster> monsters,ref int x,ref int y)
        {
            foreach (var monster in monsters)
            {
                var res = random.Next(0, 2);
                if (res == 0)
                    monster.MoveX(x, y);
                else
                    monster.MoveY(x, y);
            }
        }
        public static void Display(this List<Monster> monsters)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].Display(monsters[i].X, monsters[i].Y);
            }
        }
    }
}
