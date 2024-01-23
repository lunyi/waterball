namespace CardGame.Common
{
    public interface ICard<TSuit, TRank> : IComparable<ICard<TSuit, TRank>>
    {
        TSuit Suit { get; }
        TRank Rank { get; }
    }

    public class Card<TSuit, TRank> : ICard<TSuit, TRank>
        where TSuit : Enum
        where TRank : Enum
    {
        public TSuit Suit { get; }
        public TRank Rank { get; }

        public Card(TSuit suit, TRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int CompareTo(ICard<TSuit, TRank> other)
        {
            int rankComparison = Rank.CompareTo(other.Rank);
            if (rankComparison != 0)
            {
                return rankComparison;
            }
            return Suit.CompareTo(other.Suit);
        }
    }

}
