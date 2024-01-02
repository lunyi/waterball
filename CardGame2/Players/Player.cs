using Game;

namespace Game
{
    internal abstract class Player
    {
        static protected Random r = new Random();
        private int Point;
        public int _index { get; }
        public string Name { get; protected set; }
        protected IExchangeHands _exchangeHands { get; }
        public IHandCard Hand { get; set; }
        public abstract void SelectCard();
        public abstract void Naming(string name);

        public Player(int index)
        {
            Hand = new HandCard();
            Hand.SetPlayer(this);
            _index = index;
            _exchangeHands = new ExchangeHands();
        }

        public Card<Rank, Suit>[] ShowCards()
        {
            return Hand.ShowCards();
        }

        public void AddHandCard(dynamic card)
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
        public static (string[], int) GetCardWinner(this IList<Player> players)
        {
            var point = players.Max(player => player.GetPoint());
            var playerNames = players.Where(p => p.GetPoint() == point)
                .Select(p => p.Name)
                .ToArray();
            return (playerNames, point);
        }
    }
}
