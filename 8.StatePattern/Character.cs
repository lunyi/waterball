namespace _8.StatePattern
{
    internal class Character
    {
        private State _state;
        public Character()
        {
            
        }

        public void EnterState(State state)
        {
            _state = state;
        }

        public void Move(ref int x, ref int y, ConsoleKeyInfo keyInfo)
        {

            ClearO(x, y);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    break;
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    break;
            }

            DisplayO(x, y);
        }

        void DisplayO(int x, int y)
        {
            if (x <= 0 || y <= 0)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
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
