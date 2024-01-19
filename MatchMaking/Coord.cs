namespace MatchMaking
{
    internal class Coord
    {
        public Coord(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double GetDistance(Coord another)
        {
            return Math.Pow(another.X - X, 2) + Math.Pow(another.Y - Y, 2);
        }
    }
}
