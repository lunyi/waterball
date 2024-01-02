using Game;

namespace Game
{
    internal abstract class Player
    {
        static protected Random r = new Random();
        private int Point;
        public int _index { get; set; }
        protected string Name;
        protected IExchangeHands _exchangeHands { get; set; }
        public IHand Hand { get; set; }
        public abstract void SelectCard();
        public abstract void Naming(string name);

        public Player(int index)
        {
            Hand = new Hand();
            Hand.SetPlayer(this);
            _index = index;
            _exchangeHands = new ExchangeHands();
        }

        public string GetPlayerName()
        {
            return Name;
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
            if (_exchangeHands.IsChangeBack())
            {
                _exchangeHands.ChangeHandBack();
            }
        }

        public bool CheckIfPlayerWantToExchangeCard(IList<Player> players)
        {
            if (_exchangeHands.GetCount() == 3)
            {
                Console.WriteLine($"Hi {Name}, which player do you choose to exchange hand?");
                try
                {
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != _index && playerIndex >= 1 && playerIndex <= 4)
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
                .Select(p => p.GetPlayerName())
                .ToArray();
            return (playerNames, point);
        }
    }
}
