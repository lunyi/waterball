namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        private int Point ;
        public int Index { get; protected set; }
        public string Name { get; protected set; }
        public IExchangeHands ExchangeHands { get; protected set; }
        public Hand Hand { get; internal set; }
        public abstract void SelectCard();
        public abstract void Naming(string name);

        public Player(int index)
        {
            Hand = new Hand();
            Hand.Player = this;
            Index = index;
            ExchangeHands = new ExchangeHands();
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

        public void Clear()
        {
            Hand.ClearCards();
            ExchangeHands.Clear();
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
