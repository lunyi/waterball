namespace CardGame
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) { }

        public override void TakeTurns()
        {
            _hand.PickupCard(r.Next(1, _hand.Size()));
        }

        public override void NameHimself(string name) 
        { 
            Name = name;
        }
    }
}
