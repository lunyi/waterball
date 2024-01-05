namespace CardGame
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
        static Dictionary<Suit, string> MapSuit = new Dictionary<Suit, string>
            {
                { Suit.Club, "C" },
                { Suit.Diamond, "D" },
                { Suit.Heart,"H" },
                { Suit.Spade, "S" },
            };

        static Dictionary<Rank, string> MapRank = new Dictionary<Rank, string>
            {
                { Rank.Three, "3" },
                { Rank.Four, "4" },
                { Rank.Five, "5" },
                { Rank.Six, "6" },
                { Rank.Seven, "7" },
                { Rank.Eight, "8" },
                { Rank.Nine, "9" },
                { Rank.Ten, "10" },
                { Rank.Jack, "J" },
                { Rank.Queen, "Q" },
                { Rank.King, "K" },
                { Rank.Ace, "A" },
                { Rank.Two, "2" },
            };

        internal static bool GreatThen(this Card card, Card anotherCard)
        {
            int rankComparison = card.Rank.CompareTo(anotherCard.Rank);
            if (rankComparison != 0)
            {
                return rankComparison == 1;
            }
            return card.Suit.CompareTo(anotherCard.Suit) == 1;
        }

        internal static bool ContainClub3(this Card[] cards)
        {
            return cards.Any(p => p.Suit == Suit.Club && p.Rank == Rank.Three);
        }

        internal static void Display(this Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                Console.Write(cards[i].Rank == Rank.Ten ? $"{i}     " : $"{i}    ");
            }
            Console.WriteLine();
            for (int i = 0; i < cards.Length; i++)
            {
                Console.Write($"{MapSuit[cards[i].Suit]}[{MapRank[cards[i].Rank]}] ");
            }
            Console.WriteLine();
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
        Three = 3,
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
        Ace,
        Two
    }
}
