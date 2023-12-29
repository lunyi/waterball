namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        private int Point ;
        public int _index { get; set; }
        protected string Name ;
        protected IExchangeHands _exchangeHands { get; set; }
        public IHand _hand { get; set; }
        public abstract void TakeTurns();
        public abstract void NameHimself(string name);


        public Player(int index)
        {
            _hand = new Hand();
            _hand.SetPlayer(this);
            _index = index;
            _exchangeHands = new ExchangeHands();
        }

        public void ChangeHandBack()
        {
            _exchangeHands.ChangeHandBack();
        }
        public bool IsChangeBack()
        { 
            return _exchangeHands.IsChangeBack();
        }

        public bool MakeExchangeHandsDecision(IList<Player> players)
        {
            if (_exchangeHands.GetCountDown() == 3)
            {
                Console.WriteLine($"Hi {Name}, which player do you choose to exchange hand?");
                try
                {
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != _index && playerIndex>= 1 && playerIndex<=4)
                    {
                        var exchangee = players.FirstOrDefault(p => p._index == playerIndex);
                        _exchangeHands.ExchangeHand(this, exchangee);
                        return true;
                    }
                }
                catch
                {
                }

                Console.WriteLine($"Ok, {Name} doesn't want to change.");
                Console.WriteLine();
                return false;
            }
            else
            {
                _exchangeHands.CountDown();
            }
            return false;
        }

        public Card[] ShowCards()
        {
            return _hand.ShowCards();
        }

        public void AddHandCard(Card card)
        {
            _hand.AddHand(card);
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public void TakeTurn()
        {
            _hand.PickupCard(r.Next(1, _hand.Size()));
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
