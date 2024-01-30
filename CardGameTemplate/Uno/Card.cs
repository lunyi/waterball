namespace CardGame.Uno
{
    internal class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
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
