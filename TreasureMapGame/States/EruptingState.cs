namespace TreasureMapGame.States
{
    public class EruptingState : BaseState
    {
        private int duration;

        public EruptingState(int duration)
        {
            this.duration = duration;
        }

        public override void ApplyEffect(Player player, Map map)
        {
            /* 爆發狀態的特殊效果 */
        }
        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            player.MoveOneStep(direction, mapWidth, mapHeight);
        }
        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player entered erupting state! Attack power increased.");
        }
        public override void OnExit(Player player)
        {
            Console.WriteLine("Player exited erupting state.");
        }
        public override bool IsStateExpired()
        {
            return --duration <= 0;
        }

        public override void Attack(Player player, Map map)
        {
            // 爆發狀態下，消滅所有怪物
            map.EliminateAllMonsters();
            Console.WriteLine("All monsters eliminated by erupting attack!");
        }

        public override void ReceiveDamage(Player player, int damage)
        {
            // 爆發狀態下的受傷行為（可與正常狀態相同）
            player.HP -= damage;
            Console.WriteLine($"Player takes {damage} damage! Current HP: {player.HP}");
            if (player.HP <= 0)
            {
                Console.WriteLine("Player has been defeated by monsters!");
                Environment.Exit(0); // 結束遊戲
            }
        }
    }
}
