using TreasureMapGame.States;

namespace TreasureMapGame
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int HP { get; set; }
        public Direction Facing { get; private set; }
        public IState CurrentState { get; private set; }

        public Player(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Facing = direction;
            HP = 300;
            CurrentState = new NormalState();
        }

        public void Move(Direction direction, int mapWidth, int mapHeight)
        {
            CurrentState.Move(this, direction, mapWidth, mapHeight); // 依據狀態進行移動
        }

        public void SetState(IState newState)
        {
            CurrentState.OnExit(this); // 離開當前狀態
            CurrentState = newState;   // 設置新狀態
            CurrentState.OnEnter(this); // 進入新狀態
        }

        public void ApplyStateEffects(Map map)
        {
            CurrentState.ApplyEffect(this, map);

            if (CurrentState.IsStateExpired())
            {
                SetState(new NormalState());
            }
        }

        public void MoveOneStep(Direction direction, int mapWidth, int mapHeight)
        {
            switch (direction)
            {
                case Direction.Up: if (Y > 0) Y--; break;
                case Direction.Down: if (Y < mapHeight - 1) Y++; break;
                case Direction.Left: if (X > 0) X--; break;
                case Direction.Right: if (X < mapWidth - 1) X++; break;
            }
        }

        public char GetSymbol()
        {
            return Facing switch
            {
                Direction.Up => '↑',
                Direction.Down => '↓',
                Direction.Left => '←',
                Direction.Right => '→',
                _ => ' '
            };
        }

        public void Attack(Map map)
        {
            CurrentState.Attack(this, map); // 委托给当前状态处理
        }

        public void ReceiveDamage(int damage)
        {
            CurrentState.ReceiveDamage(this, damage); // 委托给当前状态处理
        }
    }
}
