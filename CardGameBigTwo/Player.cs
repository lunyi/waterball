namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        public int Index { get; protected set; }
        public int OrderIndex { get; set; }
        public string Name { get; protected set; }
        public Hand Hand { get; internal set; }
        public abstract void SelectCard();
        public abstract void Naming(string name);

        public Player(int index)
        {
            Hand = new Hand();
            Hand.Player = this;
            Index = index;
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

        public void Clear()
        {
            Hand.ClearCards();
        }
    }

    internal static class PlayerExtensions
    {
        internal static void SetPlayersOrder(this IList<Player> players, int startingIndex)
        {
            int orderIndex = 1;
            int totalPlayers = players.Count;

            for (int i = 0; i < totalPlayers; i++)
            {
                int currentIndex = (startingIndex + i - 1) % totalPlayers;
                players.First(p => p.Index == currentIndex + 1).OrderIndex = orderIndex++;
            }
        }

        internal static void DisplayTurn(this Player player)
        {
            Console.WriteLine($"輪到 {player.Name}, {player.Index}, {player.OrderIndex}");
        }
    }
}
