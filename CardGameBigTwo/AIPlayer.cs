namespace CardGame
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) { }

        public override void SelectCard()
        {
            Hand.SelectCard(r.Next(1, Hand.Size()));
        }

        public override void Naming(string name) 
        { 
            Name = name;
        }
    }
}
