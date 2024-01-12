namespace _8.StatePattern
{
    internal class Game
    {
        public void Start()
        {
            ConsoleKeyInfo keyInfo;
            int x = 1;
            int y = 1;
            DisplayObstacle(5, 5);
            DisplayO(x, y);
            
            do
            {
                keyInfo = Console.ReadKey(true);

                if (IsMoveAllowed(x, y, keyInfo))
                {
                    continue;
                }

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

            } while (keyInfo.Key != ConsoleKey.Escape);

            Console.WriteLine("Program ended");
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

        void DisplayObstacle(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("\u25A1");
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
