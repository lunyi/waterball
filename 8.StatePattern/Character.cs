namespace _8.StatePattern
{
    internal class Character
    {
        private State _state;
        private List<Monster> _monsters;
        public int _direction { get; set; }
        public string _dirChar { get; set; }
        public int HP { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Character(int x, int y)
        {
            HP = 300;
            X = x;
            Y = y;
        }

        public void SetMonsters(List<Monster> monsters)
        {
            _monsters = monsters;
        }

        public void EnterState(State state)
        {
            _state = state;
        }

        public (int, int) Move(ConsoleKeyInfo keyInfo)
        {
            ClearO(X, Y);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _dirChar = "\u2191";
                    Y--;
                    _direction = 8;
                    break;
                case ConsoleKey.DownArrow:
                    _dirChar = "\u2193";
                    _direction = 2;
                    Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    _dirChar = "\u2190";
                    _direction = 4;
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                    _dirChar = "\u2192";
                    _direction = 6;
                    X++;
                    break;
            }
            Display(X, Y);
            return (X, Y);
        }

        public void Display(int x, int y)
        {
            if (x <= 0 || y <= 0)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(_dirChar);
        }

        public void Display()
        {
            if (X <= 0 || Y <= 0)
            {
                return;
            }
            Console.SetCursorPosition(X, Y);
            Console.Write("O");
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
    }
}
