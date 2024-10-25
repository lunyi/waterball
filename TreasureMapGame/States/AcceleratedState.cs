namespace TreasureMapGame.States
{
    public class AcceleratedState : BaseState
    {
        private int duration;

        public AcceleratedState(int duration)
        {
            this.duration = duration;
        }

        public override void ApplyEffect(Player player, Map map)
        {
            // Accelerated state does not have a per-turn effect
        }

        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            // In Accelerated State, the player can move twice per turn
            for (int i = 0; i < 2; i++)
            {
                player.MoveOneStep(direction, mapWidth, mapHeight);
            }
        }

        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player entered Accelerated State. Can move twice per turn.");
        }

        public override void OnExit(Player player)
        {
            Console.WriteLine("Player exited Accelerated State.");
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
            // Use the default attack behavior from BaseState
            PerformLineAttack(player, map);
        }
    }
}
