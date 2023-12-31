namespace CardGame
{
    internal interface ICard
    {
        bool GreatThen(Card card);
    }

    internal class Card : ICard
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        { 
            Rank = rank;
            Suit = suit;
        }

        public bool GreatThen(Card card)
        {
            int rankComparison = Rank.CompareTo(card.Rank);
            if (rankComparison != 0)
            {
                return rankComparison == 1;
            }
            return Suit.CompareTo(card.Suit) == 1;
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
