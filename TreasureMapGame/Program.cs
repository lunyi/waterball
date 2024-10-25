namespace TreasureMapGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            var player = new Player(1, 1, Direction.Right);
            var monsters = new List<Monster>
            {
                new Monster(5, 5),
                new Monster(7, 7),
                new Monster(2, 8)
            };
            var treasures = new List<Treasure>
            {
                Treasure.GenerateRandomTreasure(3, 3),
                Treasure.GenerateRandomTreasure(6, 6),
                Treasure.GenerateRandomTreasure(4, 9)
            };


            var map = new Map(10, 10, player, monsters, treasures);

            while (true)
            {
                map.DisplayMap();

                if (map.IsGameOver())
                {
                    Console.WriteLine("All monsters defeated! You win!");
                    break;
                }

                Console.WriteLine("Choose action: (W/A/S/D to move, F to attack)");
                var input = Console.ReadKey().Key;
                Console.WriteLine();

                switch (input)
                {
                    case ConsoleKey.W: map.MovePlayer(Direction.Up); break;
                    case ConsoleKey.A: map.MovePlayer(Direction.Left); break;
                    case ConsoleKey.S: map.MovePlayer(Direction.Down); break;
                    case ConsoleKey.D: map.MovePlayer(Direction.Right); break;
                    case ConsoleKey.F: map.PlayerAttack(); break;
                    default:
                        Console.WriteLine("Invalid input. Please use W/A/S/D to move or F to attack.");
                        break;
                }

                // 更新玩家狀態效果
                player.ApplyStateEffects(map);

                // 怪物行動
                map.MoveMonsters();
            }
        }
    }
}
