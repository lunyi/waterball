namespace _3.UnoGame
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override Card SelectCard(Suit suit)
        {
            return Hand.SelectCard(suit);
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }
    }
}
