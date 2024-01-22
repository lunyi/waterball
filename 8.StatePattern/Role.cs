namespace _8.StatePattern
{
    internal class Role
    {
        private State _state;
        public int _direction { get; set; }
        public string _dirChar { get; set; }
        public int HP { get; set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Role(int x, int y)
        {
            HP = 300;
            X = x;
            Y = y;
        }

        public void EnterState(State state)
        {
            _state = state;
        }

        private (Dictionary<int, Func<Obstacle, bool>>, Dictionary<int, Func<Monster, int, bool>>) getPredicates()
        {
            Dictionary<int, Func<Obstacle, bool>> obstaclePredicates = new Dictionary<int, Func<Obstacle, bool>>
            {
                { 2, p => p.X == X && p.Y < Y },
                { 4, p => p.Y == Y && p.X < X },
                { 6, p => p.Y == Y && p.X > X },
                { 8, p => p.X == X && p.Y > Y }
            };

            // Define direction-specific monster predicates
            Dictionary<int, Func<Monster, int, bool>> monsterPredicates = new Dictionary<int, Func<Monster, int, bool>>
            {
                { 2, (p, y) => p.X == X && p.Y > y },
                { 4, (p, x) => p.Y == Y && p.X < x },
                { 6, (p, x) => p.Y == Y && p.X > x },
                { 8, (p, y) => p.X == X && p.Y < y }
            };
            return (obstaclePredicates, monsterPredicates);
        }
     
        public void Display(int x, int y)
        {
            if (x <= 0 || y <= 0 || x >= Console.BufferWidth || y >= Console.BufferHeight)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(_dirChar);
        }

        public void Display()
        {
            if (X <= 0 || Y <= 0 || X >= Console.BufferWidth || Y >= Console.BufferHeight)
            {
                return;
            }
            Console.SetCursorPosition(X, Y);
            Console.Write("O");
        }

        public void Clear()
        {
            if (X <= 0 || Y <= 0 || X >= Console.BufferWidth || Y >= Console.BufferHeight)
            {
                return;
            }
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
        public void Clear(int x, int y)
        {
            if (X <= 0 || Y <= 0 || X >= Console.BufferWidth || Y >= Console.BufferHeight)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
