namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random random = new Random();
        private int Point;
        public int Index { get; protected set; }
        public string Name { get; protected set; }
        public ExchangeHands ExchangeHands { get; protected set; }
        public Showdown Showdown { get; internal set; }
        public Hand Hand { get; internal set; }
        public abstract Card SelectCard();
        public abstract void Naming();

        public Player(int index)
        {
            Hand = new Hand();
            Index = index;
        }

        public void AddHandCard(Card card)
        {
            Hand.AddHandCard(card);
        }

        public int AddPoint()
        {
            return Point++;
        }

        public int GetPoint()
        {
            return Point;
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
