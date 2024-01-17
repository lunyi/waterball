namespace _8.StatePattern
{
    internal class Treasure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Treasure(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Display()
        {
            if (X <= 0 || Y <= 0 || X > Console.BufferWidth || Y > Console.BufferHeight)
            {
                return;
            }
            Console.SetCursorPosition(X, Y);
            Console.Write("x");
        }
    }

    internal static class TreasureExtensios
    {
        public static void Display(this List<Treasure> treasures)
        {
            for (int i = 0; i < treasures.Count; i++)
            {
                treasures[i].Display();
            }
        }
    }
}
