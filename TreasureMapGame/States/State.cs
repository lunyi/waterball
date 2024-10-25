namespace TreasureMapGame.States
{
    public interface IState
    {
        void ApplyEffect(Player player, Map map); // 增加 Map 参数
        void Move(Player player, Direction direction, int mapWidth, int mapHeight);
        void OnEnter(Player player);
        void OnExit(Player player);
        bool IsStateExpired();
        void ReceiveDamage(Player player, int damage);
        void Attack(Player player, Map map);
    }

    public abstract class BaseState : IState
    {
        public abstract void ApplyEffect(Player player, Map map);
        public abstract void Move(Player player, Direction direction, int mapWidth, int mapHeight);
        public abstract void OnEnter(Player player);
        public abstract void OnExit(Player player);
        public abstract bool IsStateExpired();
        public abstract void ReceiveDamage(Player player, int damage);

        public virtual void Attack(Player player, Map map)
        {
            // 默认的攻击行为
            PerformLineAttack(player, map);
        }

        protected void PerformLineAttack(Player player, Map map)
        {
            // 实现直线攻击的逻辑
            int dx = 0, dy = 0;
            switch (player.Facing)
            {
                case Direction.Up: dy = -1; break;
                case Direction.Down: dy = 1; break;
                case Direction.Left: dx = -1; break;
                case Direction.Right: dx = 1; break;
            }

            int x = player.X;
            int y = player.Y;

            while (true)
            {
                x += dx;
                y += dy;

                // 检查是否超出地图边界
                if (x < 0 || x >= map.Width || y < 0 || y >= map.Height)
                {
                    break;
                }

                char cell = map.GetCell(x, y);

                if (cell == 'M')
                {
                    // 消灭怪物
                    map.RemoveMonsterAt(x, y);
                    Console.WriteLine($"Monster at ({x}, {y}) eliminated!");
                }
                else if (cell == '#')
                {
                    // 遇到障碍物，攻击终止
                    break;
                }
            }
        }
    }
}
