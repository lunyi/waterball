namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        private int Point ;
        public int _index { get; set; }
        protected string Name ;

        protected ExchangeHands ExchangeHands { get; set; }
        public Hand Hand { get; set; }
        public abstract void TakeTurns();
        public abstract void NameHimself(string name);
        public abstract void makeExchangeHandsDecision(IList<Player> players);

        public Player(int index)
        {
            Hand = new Hand();
            Hand.Player = this;
            _index = index;
            ExchangeHands = new ExchangeHands();
        }

        public Card ShowCard()
        {
            return Hand.CurrentCard;
        }

        public Card[] ShowCards()
        {
            return Hand.ShowCards();
        }

        public void AddHandCard(Card card)
        {
            Hand.AddHand(card);
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public void TakeTurn()
        {
            Hand.PickupCard(r.Next(1, Hand.Size()));
        }

        public int AddPoint()
        {
            return Point++;
        }

        public int GainPoint()
        {
            return Point;
        }
    }
}
