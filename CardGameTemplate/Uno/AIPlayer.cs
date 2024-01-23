using CardGame.Common;

namespace CardGame.Uno
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override Card<Suit, Rank> SelectCard(Suit suit)
        {
            return Hand.SelectCard(suit);
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }
    }
}
