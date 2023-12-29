namespace CardGame
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) { }

        public override void TakeTurns()
        {
            Hand.PickupCard(r.Next(1, Hand.Size()));
        }

        public override void NameHimself(string name) 
        { 
            Name = name;
        }
    }
}
