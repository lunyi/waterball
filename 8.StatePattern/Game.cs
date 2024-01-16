namespace _8.StatePattern
{
    internal class Game
    {
        private Character _character;
        private List<Monster> _monsters;
        private List<Obstacle> _obstables;
        private List<Treasure> _treasures;

        public Game(Character character, List<Monster> monsters, List<Obstacle> obstables, List<Treasure> treasures)
        {
            _character = character;
            _monsters = monsters;
            _obstables = obstables;
            _treasures = treasures;
        }
        public void Start()
        {
            int x, y = 0;
            _character.Display();
            _treasures.Display();
            _obstables.Display();
            _monsters.Display();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                (x, y) =_character.Move(keyInfo);
                _monsters.Move(ref x, ref y);
            } 
            while 
            (
                keyInfo.Key != ConsoleKey.Escape
            );
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
