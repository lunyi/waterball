using Game.Card;

namespace Game.Players
{
    internal partial class Player
    {
        static protected Random r = new Random();
        public int Index { get; protected set; }
        public string Name { get; protected set; }

        public virtual void SelectCard()
        { 
        
        }
        public virtual void Naming(string name)
        { 
        
        }

        public Player(int index)
        {
            Hand = new HandCard();
            Hand.SetPlayer(this);
            Index = index;
            _exchangeHands = new ExchangeHands();
        }
    }
}
