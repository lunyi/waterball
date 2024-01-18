﻿namespace CardGame
{
    internal class Card : IComparable
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        { 
            Rank = rank;
            Suit = suit;
        }

        public int CompareTo(object? obj)
        {
            var card = obj as Card;
            int rankComparison = Rank.CompareTo(card.Rank);
            if (rankComparison != 0)
            {
                return rankComparison;
            }
            return Suit.CompareTo(card.Suit);
        }
    }

    internal static class CardExtension
    {
        internal static bool GreatThan(this Card card, Card anotherCard)
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
