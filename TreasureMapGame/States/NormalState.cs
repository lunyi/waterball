namespace TreasureMapGame.States
{
    public class NormalState : BaseState
    {
        public NormalState()
        {
            // NormalState 沒有持續時間
        }

        public override void ApplyEffect(Player player, Map map)
        {
            // 正常狀態下沒有每回合的特殊效果
        }

        public override void Move(Player player, Direction direction, int mapWidth, int mapHeight)
        {
            // 正常移動
            player.MoveOneStep(direction, mapWidth, mapHeight);
        }

        public override void OnEnter(Player player)
        {
            Console.WriteLine("Player is in Normal State.");
        }

        public override void OnExit(Player player)
        {
            // 離開正常狀態時無需特殊處理
        }

        public override bool IsStateExpired()
        {
            // 正常狀態不會過期
            return false;
        }

        public override void ReceiveDamage(Player player, int damage)
        {
            // 正常的受傷處理
            player.HP -= damage;
            Console.WriteLine($"Player takes {damage} damage! Current HP: {player.HP}");
            if (player.HP <= 0)
            {
                Console.WriteLine("Player has been defeated!");
                Environment.Exit(0); // 結束遊戲
            }
        }

        public override void Attack(Player player, Map map)
        {
            // 使用預設的攻擊行為
            PerformLineAttack(player, map);
        }
    }
}
