namespace _8.StatePattern
{
    internal class TreasureState
    {
        public int BeginPoint { get; set; }
        public int EndPoint { get; set; }
        public State State { get; set; }
        public TreasureState(int index, int points, State state)
        {
            BeginPoint = index;
            EndPoint = index + points;
            State = state;
        }
    }
}
