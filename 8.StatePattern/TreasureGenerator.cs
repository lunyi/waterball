using _8.StatePattern.States;

namespace _8.StatePattern
{
    internal class TreasureGenerator
    {
        static Random random = new Random();
        public TreasureGenerator() { }

        private List<TreasureState> TreasureMap = new List<TreasureState>
        {
            new TreasureState( 0, 10, new StockpileState()),
            new TreasureState(10, 25, new PoisonedState()),
            new TreasureState(35, 20, new AcceleratedState()),
            new TreasureState(55, 15, new HealingState()),
            new TreasureState(70, 10, new StockpileState()),
            new TreasureState(80, 10, new EruptingState()),
            new TreasureState(90, 10, new TeleportState())
        };

        public State GetState(Role role)
        {
            var key = random.Next(0, 100);

            foreach (var map in TreasureMap)
            {
                if (key >= map.BeginPoint && key < map.EndPoint)
                {
                    var state = map.State;
                    state.SetRole(role);
                    return state;
                }
            }
            return null;
        }
    }
}
