namespace _8.StatePattern
{
    internal class Monster
    {
        private int _x;
        private int _y;
        public Monster(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Move(int x, int y)
        {
            ClearO(_x, _y);
            _x = x > _x ? _x++ : _x--;
            _y = y > _y ? _y++ : _y--;
            Display(_x, _y);
        }

        void ClearO(int x, int y)
        {
            if (x <= 0 || y <= 0)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        private void Display(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("\u25A1");
        }
    }

    internal static class MonsterExtensios
    {
        public static void Move(this List<Monster> monsters, int x, int y)
        {
            for (int i = 0; i < monsters.Count; i++) 
            {
                monsters[i].Move(x, y);
            }
        }
    }
}
