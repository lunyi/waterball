using System.Runtime.CompilerServices;

namespace Game
{

    internal class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Rank = rank;
            Suit = suit;
        }
    }

    internal static class CardExtensions
    {
        internal static bool GreatThen(this Card card, Card anotherCard)
        {
            int rankComparison = card.Rank.CompareTo(anotherCard.Rank);
            if (rankComparison != 0)
            {
                return rankComparison == 1;
            }
            return card.Suit.CompareTo(anotherCard.Suit) == 1;
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
