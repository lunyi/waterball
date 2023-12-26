namespace CardGame
{
    internal class Card
    {


        public Suit Suits { get; set; }
        public Rank Ranks { get; set; }

        public Card(Suit suit, Rank rank)
        { 
            Ranks = rank;
            Suits = suit;
        }
    }

    internal enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }

    internal class Ranks
    {
        public string Signal { get; set; }
        public int Number { get; set; }
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
