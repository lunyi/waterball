namespace Game
{

    internal class Card<TRank, TSuit>
    {
        public TSuit Suits { get; set; }
        public TRank Ranks { get; set; }

        public Card(TSuit suit, TRank rank)
        {
            Suits = suit;
            Ranks = rank;
        }
    }

    internal static class CardExtensions
    {
        internal static bool GreatThen(this Card<Rank,Suit> card, Card<Rank,Suit> anotherCard)
        {
            int rankComparison = card.Ranks.CompareTo(anotherCard.Ranks);
            if (rankComparison != 0)
            {
                return rankComparison == 1;
            }
            return card.Suits.CompareTo(anotherCard.Suits) == 1;
        }
    }
    internal enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }

    internal enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
