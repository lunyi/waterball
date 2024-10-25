namespace TreasureMapGame.States
{
    public class StockpileState : BaseState
    {
        private int duration;
        private bool hasTransitioned = false;

        public StockpileState(int duration)
        {
            this.duration = duration;
        }

        public override void ApplyEffect(Player player, Map map)
        {
            // Stockpile State does not have a per-turn effect until it transitions
            if (!hasTransitioned && IsStateExpired())
            {
                player.SetState(new EruptingState(3)); // Transition to Erupting State, lasts for 3 turns
                Console.WriteLine("Player has entered Erupting State after Stockpile!");
                hasTransitioned = true;
            }
        }

        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            // Normal movement in Stockpile State
            player.MoveOneStep(direction, mapWidth, mapHeight);
        }

        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player entered Stockpile State. Preparing for eruption!");
        }

        public override void OnExit(Player player)
        {
            Console.WriteLine("Player exited Stockpile State.");
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
