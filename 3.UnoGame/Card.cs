namespace _3.UnoGame
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

    internal enum Suit
    {
        Green,
        Yellow,
        Blue,
        Red
    }

    internal enum Rank
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten
    }
}
