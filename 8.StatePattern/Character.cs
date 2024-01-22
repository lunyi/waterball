namespace _8.StatePattern
{
    internal class Character  : Role
    {
        private List<Monster> _monsters;
        private List<Obstacle> _obstacles;
        public int _direction { get; set; }
        public string _dirChar { get; set; }
        public int HP { get; set; }

        public Character(int x, int y) : base(x, y)
        {
            HP = 300;
        }

        public void SetMonsters(List<Monster> monsters)
        {
            _monsters = monsters;
        }

        public void SetObstacles(List<Obstacle> obstacles)
        {
            _obstacles = obstacles;
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
                case ConsoleKey.A:
                    Attack();
                    break;
            }
            Display(X, Y);
            return (X, Y);
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
        private void Attack()
        {
            Dictionary<int, Func<Obstacle, bool>> obstaclePredicates;
            Dictionary<int, Func<Monster, int, bool>> monsterPredicates;
            (obstaclePredicates, monsterPredicates) = getPredicates();

            int direction = _direction;
            var obstacle = _obstacles
                .Where(obstaclePredicates[direction])
                .OrderBy(p => (X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y))
                .FirstOrDefault();

            var coordinate = obstacle != null ? new { X = obstacle.X, Y = obstacle.Y } : new { X, Y };

            var monsters = _monsters
                .Where(p => monsterPredicates[direction](p, coordinate.Y))
                .ToList();

            foreach (var monster in monsters)
            {
                monster.Clear();
                _monsters.Remove(monster);
            }
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

        void ClearO(int x, int y)
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
