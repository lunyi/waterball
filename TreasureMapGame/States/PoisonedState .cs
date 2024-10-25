namespace TreasureMapGame.States
{
    public class PoisonedState : BaseState
    {
        private int duration;

        public PoisonedState(int duration)
        {
            this.duration = duration;
        }

        public override void ApplyEffect(Player player, Map map)
        {
            // Player loses 15 HP each turn due to poison
            player.HP -= 15;
            Console.WriteLine($"Player is poisoned! Lost 15 HP, current HP: {player.HP}");
            if (player.HP <= 0)
            {
                Console.WriteLine("Player has been defeated by poison!");
                Environment.Exit(0); // End the game
            }
        }

        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            // Normal movement
            player.MoveOneStep(direction, mapWidth, mapHeight);
        }

        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player entered Poisoned State.");
        }

        public override void OnExit(Player player)
        {
            Console.WriteLine("Player exited Poisoned State.");
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
