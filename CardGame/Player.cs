namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        private int Point ;
        public int Index { get; protected set; }
        public string Name { get; protected set; }
        protected IExchangeHands _exchangeHands { get; set; }
        public IHand Hand { get; set; }
        public abstract void SelectCard();
        public abstract void Naming(string name);

        public Player(int index)
        {
            Hand = new Hand();
            Hand.SetPlayer(this);
            Index = index;
            _exchangeHands = new ExchangeHands();
        }

        public Card[] ShowCards()
        {
            return Hand.ShowCards();
        }

        public void AddHandCard(Card card)
        {
            Hand.AddHandCard(card);
        }

        public void DrawCard()
        {
            Hand.SelectCard(r.Next(1, Hand.Size()));
        }

        public int AddPoint()
        {
            return Point++;
        }

        public int GetPoint()
        {
            return Point;
        }

        public void ChangeHandBack()
        {
            _exchangeHands.ChangeHandBack();
        }

        public bool CheckIfPlayerWantToExchangeCard(IList<Player> players)
        {
            return _exchangeHands.CheckIfPlayerWantToExchangeCard(this, players);
        }

        public void Clear()
        {
            Hand.ClearCards();
            _exchangeHands.Clear();
            Point = 0;
        }
    }

    internal static class PlayerExtensions
    {
        public static (string[], int) GetFinalWinner(this IList<Player> players)
        {
            var point = players.Max(player => player.GetPoint());
            var playerNames = players.Where(p => p.GetPoint() == point)
                .Select(p=>p.Name)
                .ToArray();
            return (playerNames, point);
        }
    }
}
