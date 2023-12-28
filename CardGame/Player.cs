namespace CardGame
{
    internal abstract class Player 
    {
        private int Point ;
        protected string Name ;
        private bool exchangeHand = false ;
        private Hand hand ;

        public abstract void NameHimself(string name);
        public abstract void makeExchangeHandsDecision();

        public Player()
        {
            hand = new Hand();
            hand.Player = this;
        }

        public Hand GetHand()
        {
            return hand;
        }

        public Card[] ShowCards()
        {
            return hand.ShowCards();
        }

        public bool GetExchangeHand()
        { 
            return exchangeHand;
        }
        public void SetExchangeHand()
        {
            exchangeHand = true;
        }

        public void AddHandCard(Card card)
        {
            hand.AddHand(card);
        }
        public void PickupCard(int index)
        {
            hand.PickupCard(index);
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public void TakeTurn()
        { 
        
        }

        public int AddPoint()
        {
            return Point++;
        }

        public int GainPoint()
        {
            return Point;
        }

        public void ExchangeHands(Player exchangee)
        { 

        }
    }
}
