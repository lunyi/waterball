namespace _8.StatePattern
{
    internal class Game
    {
        private Character _character;
        private List<Monster> _monsters;
        private List<Obstacle> _obstables;
        private List<Treasure> _treasures;
        private Touch _touch;

        public Game(Character character, 
            List<Monster> monsters, 
            List<Obstacle> obstables, 
            List<Treasure> treasures,
            Touch touch)
        {
            _character = character;
            _monsters = monsters;
            _obstables = obstables;
            _treasures = treasures;
            _touch = touch;
        }
        public void Start()
        {
            int x = 0, y = 0;
            _character.Display();
            _treasures.Display();
            _obstables.Display();
            _monsters.Display();
            bool stuck = false;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (!stuck)
                {
                    (x, y) = _character.Move(keyInfo);
                }

                stuck = _touch.CheckIfTouchCharacterAndObstacles(_character, _obstables);
                if (stuck)
                {
                    continue;
                }
                _touch.CheckIfTouchCharacterAndTreasures(_character, _treasures);
                _touch.CheckIfTouchCharacterAndMonsters(_character, _monsters);

                _monsters.Move(ref x, ref y);
                _touch.CheckIfTouchCharacterAndTreasures(_character, _treasures);
                _touch.CheckIfTouchTreasuresAndMonsters(_monsters, _treasures);

                checkIfFinished();
            } 
            while 
            (
                keyInfo.Key != ConsoleKey.Escape
            );
            Console.WriteLine("Program ended");
        }

        private void checkIfFinished()
        {
            if (_monsters.Count == 0)
            { 
                Console.WriteLine("遊戲結束");
            }
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
