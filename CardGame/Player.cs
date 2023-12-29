namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        private int Point ;
        public int _index { get; set; }
        protected string Name ;
        public delegate void OnDrawPlayerCardsDelegate(IList<Player> players);
        public OnDrawPlayerCardsDelegate OnDrawPlayerCards = null;

        protected ExchangeHands _exchangeHands { get; set; }
        public Hand Hand { get; set; }
        public abstract void TakeTurns();
        public abstract void NameHimself(string name);

        public Player(int index)
        {
            Hand = new Hand();
            Hand.Player = this;
            _index = index;
            _exchangeHands = new ExchangeHands();
        }
        public bool MakeExchangeHandsDecision(IList<Player> players)
        {
            if (_exchangeHands.GetCountDown() == 3)
            {
                Console.WriteLine($"Hi {Name}, which player do you choose to exchange hand?");
                try
                {
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != _index)
                    {
                        _exchangeHands.ExchangeHand(this, players.FirstOrDefault(p => p._index == playerIndex));
                        return true;
                    }
                }
                catch
                {
                }

                Console.WriteLine($"Ok, {Name} doesn't want to change.");
                return false;
            }
            else
            {
                _exchangeHands.CountDown();

                if (_exchangeHands.GetCountDown() == 0)
                {
                    OnDrawPlayerCards(players);
                }
            }
            return false;
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
