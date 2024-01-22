namespace _8.StatePattern
{
    internal class Treasure : Role
    {
        public Treasure(int x, int y) : base(x, y)
        {

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
