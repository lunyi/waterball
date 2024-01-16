namespace _8.StatePattern
{
    internal class Obstacle
    {
        public int _x { get; private set; }
        public int _y { get; private set; }

        public Obstacle(int x, int y)
        {
            _x = x;
            _y = y;
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
            Console.WriteLine("\u25A1");
        }
    }

    internal static class ObstacleExtensios
    {
        public static void Display(this List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].Display(obstacles[i]._x, obstacles[i]._y);
            }
        }
    }
}
