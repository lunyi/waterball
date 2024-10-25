using TreasureMapGame.States;

namespace TreasureMapGame
{
    public class Treasure
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private IState treasureState;

        public Treasure(int x, int y, IState treasureState)
        {
            X = x;
            Y = y;
            this.treasureState = treasureState;
        }

        public void ApplyEffect(Player player)
        {
            player.SetState(treasureState);  // 當玩家觸碰寶物時，設置新的狀態
            Console.WriteLine($"Player picked up a treasure and gained {treasureState.GetType().Name} state!");
        }

        public static Treasure GenerateRandomTreasure(int x, int y)
        {
            Random random = new Random();
            double chance = random.NextDouble();

            if (chance <= 0.1)
            {
                return new Treasure(x, y, new InvincibleState(2)); // 無敵狀態
            }
            else if (chance <= 0.25)
            {
                return new Treasure(x, y, new PoisonedState(3)); // 中毒狀態
            }
            else if (chance <= 0.45)
            {
                return new Treasure(x, y, new AcceleratedState(3)); // 加速狀態
            }
            else if (chance <= 0.6)
            {
                return new Treasure(x, y, new HealingState(5)); // 恢復狀態
            }
            else if (chance <= 0.7)
            {
                return new Treasure(x, y, new StockpileState(2)); // 蓄力狀態
            }
            else if (chance <= 0.8)
            {
                return new Treasure(x, y, new EruptingState(3)); // 爆發狀態
            }
            else
            {
                return new Treasure(x, y, new TeleportState(1)); // 瞬身狀態
            }
        }
    }
}
