namespace TreasureMapGame.States
{
    public class InvincibleState : BaseState
    {
        private int duration;

        public InvincibleState(int duration)
        {
            this.duration = duration;
        }

        public override void ApplyEffect(Player player, Map map)
        {
            // Invincible State does not have a per-turn effect
            // The invincibility is handled in the ReceiveDamage method
        }

        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            // Normal movement
            player.MoveOneStep(direction, mapWidth, mapHeight);
        }

        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player entered Invincible State. Cannot be harmed!");
        }

        public override void OnExit(Player player)
        {
            Console.WriteLine("Player exited Invincible State.");
        }

        public override bool IsStateExpired()
        {
            return --duration <= 0;
        }

        public override void ReceiveDamage(Player player, int damage)
        {
            // In Invincible State, the player does not take any damage
            Console.WriteLine("Player is invincible! No damage taken.");
        }

        public override void Attack(Player player, Map map)
        {
            // Use the default attack behavior
            PerformLineAttack(player, map);
        }
    }
}
