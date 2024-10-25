namespace TreasureMapGame
{
    public enum Direction { Up, Down, Left, Right }

    public class Map
    {
        private char[,] map;
        public int Width { get; private set; }
        public int Height { get; private set; }
        private Player player;
        private List<Monster> monsters;
        private List<Treasure> treasures;
        private Random random = new Random();

        public Map(int width, int height, Player player, List<Monster> monsters, List<Treasure> treasures)
        {
            this.Width = width;
            this.Height = height;
            this.player = player;
            this.monsters = monsters;
            this.treasures = treasures;
            map = new char[height, width];
            GenerateMap();
        }

        public void GenerateMap()
        {
            // Initialize empty map with obstacles randomly
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    map[i, j] = (random.Next(0, 10) < 2) ? '#' : ' ';
                }
            }

            // Place player
            PlacePlayer();

            // Place monsters
            foreach (var monster in monsters)
            {
                map[monster.Y, monster.X] = 'M';
            }

            // Place treasures
            foreach (var treasure in treasures)
            {
                map[treasure.Y, treasure.X] = 'T';
            }
        }

        public void DisplayMap()
        {
            Console.Clear();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Player HP: {player.HP}, State: {player.CurrentState}");
        }

        public void MovePlayer(Direction direction)
        {
            map[player.Y, player.X] = ' '; // Clear previous position
            player.Move(direction, Width, Height);
            map[player.Y, player.X] = player.GetSymbol(); // Update new position
        }

        public void PlayerAttack2()
        {
            player.Attack(this); // 由玩家对象处理攻击行为
        }

        public void PlayerAttack()
        {
            int dx = 0, dy = 0;
            switch (player.Facing)
            {
                case Direction.Up: dy = -1; break;
                case Direction.Down: dy = 1; break;
                case Direction.Left: dx = -1; break;
                case Direction.Right: dx = 1; break;
            }

            int x = player.X, y = player.Y;
            while (x + dx >= 0 && x + dx < Width && y + dy >= 0 && y + dy < Height)
            {
                x += dx;
                y += dy;
                if (map[y, x] == 'M')
                {
                    Console.WriteLine("Monster eliminated!");
                    map[y, x] = ' ';
                    monsters.RemoveAll(m => m.X == x && m.Y == y);
                }
                if (map[y, x] == '#')
                {
                    break;
                }
            }
        }

        private void MonsterAttackPlayer(Monster monster)
        {
            Console.WriteLine($"Monster at ({monster.X}, {monster.Y}) attacks the player!");
            player.ReceiveDamage(20); // 直接调用玩家的受伤方法
        }

        public void MoveMonsters()
        {
            foreach (var monster in monsters)
            {
                map[monster.Y, monster.X] = ' '; // Clear monster position
                monster.MoveTowardsPlayer(player.X, player.Y, Width, Height);
                if (map[monster.Y, monster.X] != ' ') // Collision detection
                {
                    monster.UndoMove();
                }
                map[monster.Y, monster.X] = 'M';
            }
        }

        public bool IsGameOver()
        {
            return monsters.Count == 0;
        }

        private void PlacePlayer()
        {
            if (IsPositionEmpty(player.X, player.Y))
            {
                map[player.Y, player.X] = player.GetSymbol();
            }
            else
            {
                // 如果位置被佔用，重新隨機一個位置
                player.X = random.Next(0, Width);
                player.Y = random.Next(0, Height);
                map[player.Y, player.X] = player.GetSymbol();
            }
        }
        public bool IsPositionEmpty(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return false;

            char cell = map[y, x];
            return cell == ' ';
        }

        public char GetCell(int x, int y)
        {
            return map[y, x];
        }

        public void RemoveMonsterAt(int x, int y)
        {
            Monster monsterToRemove = null;
            foreach (var monster in monsters)
            {
                if (monster.X == x && monster.Y == y)
                {
                    monsterToRemove = monster;
                    break;
                }
            }

            if (monsterToRemove != null)
            {
                monsters.Remove(monsterToRemove);
                map[y, x] = ' '; // 移除地图上的怪物符号
            }
        }

        public void EliminateAllMonsters()
        {
            foreach (var monster in monsters)
            {
                map[monster.Y, monster.X] = ' ';
            }
            monsters.Clear();
        }
    }
}
