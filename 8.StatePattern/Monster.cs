namespace _8.StatePattern
{
    internal class Monster : Role
    {
        public Monster(int x, int y) : base(x, y)
        {

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
