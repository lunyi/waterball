namespace CardGame
{
    internal abstract class Player 
    {
        private int Point ;
        protected string Name ;
        private bool exchangeHand = false ;

        private Hand hand = new Hand();

        public abstract void NameHimself(string name);
        public abstract void makeExchangeHandsDecision();
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

        public Card PickupCard(int index)
        {
            return hand.PickupCard(index);
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public void TakeTurn()
        { 
        
        }

        public void GainPoint()
        { 

        }

        public void ExchangeHands(Player exchangee)
        { 

        }
    }
}
