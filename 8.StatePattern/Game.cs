namespace _8.StatePattern
{
    internal class Game
    {
        private Character _character;
        private List<Monster> _monsters;

        public Game(Character character, List<Monster> monsters)
        {
            _character = character;
            _monsters = monsters;
        }
        public void Start()
        {
            ConsoleKeyInfo keyInfo;
            int x = 1;
            int y = 1;
            
            do
            {
                keyInfo = Console.ReadKey(true);
                _character.Move(ref x, ref y, keyInfo);
                _monsters.Move(x, y);
            } 
            while (keyInfo.Key != ConsoleKey.Escape);

            Console.WriteLine("Program ended");
        }



        static bool IsMoveAllowed(int x, int y, ConsoleKeyInfo keyInfo)
        {
            // Check if the next position is within bounds (5, 5)
            if ((keyInfo.Key == ConsoleKey.UpArrow && y == 5 && x == 5) ||
                (keyInfo.Key == ConsoleKey.DownArrow && y == 5 && x == 5) ||
                (keyInfo.Key == ConsoleKey.LeftArrow && x == 5 && y == 5) ||
                (keyInfo.Key == ConsoleKey.RightArrow && x == 5 && y == 5))
            {
                return true;
            }

            return false;
        }
    }
}
