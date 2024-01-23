using CardGame.Common;

namespace CardGame.Poke
{
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

    internal static class CardExtension
    {
        internal static bool GreatThan(this Card<Rank,Suit> card, Card<Rank, Suit> anotherCard)
        {
            int rankComparison = card.Rank.CompareTo(anotherCard.Rank);
            if (rankComparison != 0)
            {
                return rankComparison == 1;
            }
            return card.Suit.CompareTo(anotherCard.Suit) == 1;
        }
    }

}
