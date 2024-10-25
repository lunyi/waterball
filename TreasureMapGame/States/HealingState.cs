namespace TreasureMapGame.States
{
    public class HealingState : BaseState
    {
        private int duration;

        public HealingState(int duration)
        {
            this.duration = duration;
        }

        public override void ApplyEffect(Player player, Map map)
        {
            // Heal the player by 30 HP each turn, up to a maximum of 300 HP
            int previousHP = player.HP;
            player.HP = Math.Min(player.HP + 30, 300);
            Console.WriteLine($"Player is healing! Gained {player.HP - previousHP} HP, current HP: {player.HP}");
        }

        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            // Normal movement
            player.MoveOneStep(direction, mapWidth, mapHeight);
        }

        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player entered Healing State.");
        }

        public override void OnExit(Player player)
        {
            Console.WriteLine("Player exited Healing State.");
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
