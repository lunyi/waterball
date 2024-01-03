namespace Game.Uno
{
    internal class Card<TRank, TSuit> 
        where TRank: Enum
        where TSuit : Enum
    {
        public TSuit Suits { get; set; }
        public TRank Ranks { get; set; }

        public Card(TSuit suit, TRank rank)
        {
            Suits = suit;
            Ranks = rank;
        }
    }

    internal enum RankUno
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }

    internal enum SuitUno
    {
        Blue,
        Red,
        Yellow,
        Green
    }
}
