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

        internal static bool GreatThan(this Card card, Card anotherCard)
        {
            int rankComparison = card.Rank.CompareTo(anotherCard.Rank);
            if (rankComparison != 0)
            {
                return rankComparison == 1;
            }
            return card.Suit.CompareTo(anotherCard.Suit) == 1;
        }

        internal static bool ContainClub3(this List<Card> cards)
        {
            return cards.Any(p => p.Suit == Suit.Club && p.Rank == Rank.Three);
        }

        internal static List<Card> SortCards(this List<Card> cards)
        {
            if (cards == null)
            { 
                return new List<Card>();
            }
            return cards.OrderBy(p => p.Rank).ThenBy(p => p.Suit).ToList();
        }

        internal static bool IsStraightFlush(this List<Card> hand)
        {
            // Group cards by suit
            var groupedBySuit = hand.GroupBy(c => c.Suit);

            // Check if any suit has a straight
            foreach (var group in groupedBySuit)
            {
                var sortedCards = group.OrderBy(c => (int)c.Rank).ToList();

                // Check for a sequence of consecutive ranks
                for (int i = 0; i < sortedCards.Count - 1; i++)
                {
                    if ((int)sortedCards[i + 1].Rank - (int)sortedCards[i].Rank != 1)
                    {
                        break; // Not a straight
                    }

                    if (i == sortedCards.Count - 2)
                    {
                        return true; // Found a straight in this suit
                    }
                }
            }

            return false; // No straight found in any suit
        }

        internal static List<Card> GetStraightFlush(this List<Card> hand)
        {
            // Group cards by suit
            var groupedBySuit = hand.GroupBy(c => c.Suit);

            // Check if any suit has a straight
            foreach (var group in groupedBySuit)
            {
                var sortedCards = group.OrderBy(c => (int)c.Rank).ToList();

                // Check for a sequence of consecutive ranks
                for (int i = 0; i < sortedCards.Count - 1; i++)
                {
                    if ((int)sortedCards[i + 1].Rank - (int)sortedCards[i].Rank != 1)
                    {
                        break; // Not a straight
                    }

                    if (i == sortedCards.Count - 2)
                    {
                        return sortedCards; // Found a straight in this suit
                    }
                }
            }

            return null; // No straight found in any suit
        }

        internal static bool IsFourOfAKind(this List<Card> hand)
        {
            // Group cards by rank
            var groupedByRank = hand.GroupBy(c => c.Rank);

            // Check if any group has four cards (four of a kind)
            return groupedByRank.Any(group => group.Count() == 4);
        }

        internal static List<Card> GetFourOfAKind(this List<Card> hand)
        {
            // Group cards by rank
            var groupedByRank = hand.GroupBy(c => c.Rank);

            // Find a group with four cards (four of a kind)
            var fourOfAKindGroup = groupedByRank.FirstOrDefault(group => group.Count() == 4);

            if (fourOfAKindGroup != null)
            {
                // Get the four cards of the same rank
                var fourOfAKind = fourOfAKindGroup.ToList();

                // Find the fifth card
                var fifthCard = hand.FirstOrDefault(card => card.Rank != fourOfAKind[0].Rank);

                if (fifthCard != null)
                {
                    // Add the fifth card to the four of a kind
                    fourOfAKind.Add(fifthCard);
                    return fourOfAKind;
                }
            }

            return null; // No four of a kind found
        }

        internal static bool IsStraight(this List<Card> cards)
        {
            // Sort the cards based on ranks
            var sortedCards = cards.OrderBy(c => (int)c.Rank).ToArray();

            // Check for a sequence of consecutive ranks
            for (int i = 0; i < sortedCards.Length - 1; i++)
            {
                if ((int)sortedCards[i + 1].Rank - (int)sortedCards[i].Rank != 1)
                {
                    return false; // Not a straight
                }
            }

            return true; // It's a straight
        }

        internal static bool IsFullHouse(this List<Card> cards)
        {
            // Group cards by rank
            var groupedByRank = cards.GroupBy(c => c.Rank).ToList();

            // Check for a set of 3 and a set of 2
            return groupedByRank.Any(group => group.Count() == 3) &&
                   groupedByRank.Any(group => group.Count() == 2);
        }
        internal static void Display(this List<Card> cards, bool showOrder = false)
        {
            if (showOrder)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    Console.Write(cards[i].Rank == Rank.Ten ? $"{i}     " : $"{i}    ");
                }
            }

            Console.WriteLine();
            for (int i = 0; i < cards.Count; i++)
            {
                Console.Write($"{MapSuit[cards[i].Suit]}[{MapRank[cards[i].Rank]}] ");
            }
            Console.WriteLine();
        }

        internal static List<Card> GetSingle(this List<Card> cards, Card specificCard)
        {
            var temps = cards.Where(p => p.GreatThan(specificCard)).ToList();
            if (temps == null || temps.Count == 0)
            {
                return null;
            }
            var target = temps.SortCards()[0];
            return new List<Card> { target };
        }

        internal static List<Card> GetPair(this List<Card> cards, Card specificCard, Func<Card, Card, bool>compareToCard)
        {
            var groupedByRank = cards.GroupBy(c => c.Rank).ToList();

            // Find a pair with a specific card
            var pair = groupedByRank.FirstOrDefault(group => group.Count() == 2 && group.Any(c => compareToCard(c, specificCard)));

            // Check if a pair is found
            if (pair != null)
            {
                return pair.ToList();
            }

            return null;
        }

        internal static List<Card> GetFullHouse(this List<Card> cards, Card specificCard, Func<Card, Card, bool> compareToCard)
        {
            // Group cards by rank
            var groupedByRank = cards.GroupBy(c => c.Rank).ToList();

            // Find a set of 3 and a set of 2 with a specific card
            var threeOfAKind = groupedByRank.FirstOrDefault(group => group.Count() >= 3 && group.Any(c => compareToCard(c, specificCard)));
            var pair = groupedByRank.FirstOrDefault(group => group.Count() >= 2 && group.Key != threeOfAKind?.Key);

            // Check if both sets are found
            if (threeOfAKind != null && pair != null)
            {
                // Combine the sets to form a full house
                var fullHouse = threeOfAKind.Concat(pair).ToList();
                return fullHouse;
            }

            return null;
        }

        internal static List<Card> GetStraight(this List<Card> cards, Card specificCard, Func<Card, Card, bool> compareToCard)
        {
            // Filter cards with rank greater than or equal to the specific card's rank
            var filteredCards = cards.Where(c => compareToCard(c, specificCard)).Distinct().ToList();

            // Sort the filtered cards based on ranks
            var sortedCards = filteredCards.OrderBy(c => (int)c.Rank).ToArray();

            // Find the biggest straight starting from the specific card
            for (int i = sortedCards.Length - 5; i >= 0; i--)
            {
                if (IsConsecutive(sortedCards, i, i + 4))
                {
                    return sortedCards.Skip(i).Take(5).ToList();
                }
            }

            return null;
        }

        internal static bool IsConsecutive(Card[] cards, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                if ((int)cards[i + 1].Rank - (int)cards[i].Rank != 1)
                {
                    return false;
                }
            }
            return true;
        }

        internal static Rank NextRank(this Rank currentRank)
        {
            int nextValue = (int)currentRank + 1;

            // Check if the next value is within the range of defined enum values
            if (Enum.IsDefined(typeof(Rank), nextValue))
            {
                return (Rank)nextValue;
            }
            else
            {
                // If it's outside the range, wrap around to the first enum value
                return (Rank)Enum.GetValues(typeof(Rank)).Cast<int>().Min();
            }
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
