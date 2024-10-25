namespace TreasureMapGame.States
{
    public class TeleportState : BaseState
    {
        private int duration;
        private bool hasTeleported = false;

        public TeleportState(int duration)
        {
            this.duration = duration;
        }

        public override void ApplyEffect(Player player, Map map)
        {
            if (!hasTeleported)
            {
                // Teleport the player to a random empty position on the map
                Random random = new Random();
                int newX, newY;

                do
                {
                    newX = random.Next(0, map.Width);
                    newY = random.Next(0, map.Height);
                } while (!map.IsPositionEmpty(newX, newY));

                // Update player's position
                player.X = newX;
                player.Y = newY;

                Console.WriteLine($"Player teleported to ({newX}, {newY})!");
                hasTeleported = true;
            }
        }

        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            // Normal movement
            player.MoveOneStep(direction, mapWidth, mapHeight);
        }

        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player entered Teleport State.");
            // The teleportation occurs in ApplyEffect
        }

        public override void OnExit(Player player)
        {
            Console.WriteLine("Player exited Teleport State.");
        }

        public override bool IsStateExpired()
        {
            return --duration <= 0;
        }

        public override void ReceiveDamage(Player player, int damage)
        {
            // Normal damage handling
            player.HP -= damage;
            Console.WriteLine($"Player takes {damage} damage! Current HP: {player.HP}");
            if (player.HP <= 0)
            {
                Console.WriteLine("Player has been defeated!");
                Environment.Exit(0); // End the game
            }
        }

        public override void Attack(Player player, Map map)
        {
            // Use the default attack behavior
            PerformLineAttack(player, map);
        }
    }

}
