namespace _8.StatePattern
{
    internal class Obstacle : Role
    {
        public Obstacle(int x, int y) : base(x, y) 
        {

        }
    }

    internal static class ObstacleExtensios
    {
        public static void Display(this List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].Display(obstacles[i].X, obstacles[i].Y);
            }
        }
    }
}
