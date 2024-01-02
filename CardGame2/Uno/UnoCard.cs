using System.Runtime.CompilerServices;

namespace Game.Uno
{
    internal class UnoCard
    {
        public SuitUno Suit { get; set; }
        public RankUno Rank { get; set; }

        public UnoCard(SuitUno suit, RankUno rank)
        {
            Rank = rank;
            Suit = suit;
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
