using CardGame.Common;

namespace CardGame.Common
{ 
    internal abstract class Player<TSuit, TRank>
        where TSuit : Enum
        where TRank : Enum
    {
        static protected Random random = new Random();
        private int Point;
        public int Index { get; protected set; }
        public string Name { get; protected set; }
        public Hand<TSuit, TRank> Hand { get; internal set; }
        public abstract Card<TSuit, TRank> SelectCard(TSuit suit);
        public abstract void Naming();

        public Player(int index)
        {
            Hand = new Hand<TSuit, TRank>();
            Index = index;
        }

        public void AddHandCard(Card<TSuit, TRank> card)
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
        public static (string[], int) GetFinalWinner<TSuit, TRank>(this IList<Player<TSuit,TRank>> players)
            where TSuit : Enum
            where TRank : Enum
        {
            var point = players.Max(player => player.GetPoint());
            var playerNames = players.Where(p => p.GetPoint() == point)
                .Select(p=>p.Name)
                .ToArray();
            return (playerNames, point);
        }
    }
}
