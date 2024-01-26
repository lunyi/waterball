using CardGame.Common;

namespace CardGame.Uno
{
    internal class AIPlayer : Player<Suit, Rank>
    {
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }

        public override Card<Suit, Rank> SelectCard(Suit suit)
        {
            return Hand.SelectCard(suit);
        }

        public override Card<Suit, Rank> SelectCard()
        {
            throw new NotImplementedException();
        }
    }
}
