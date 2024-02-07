using System.ComponentModel;
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
        [Description("G")]
        Green,
        [Description("Y")]
        Yellow,
        [Description("B")]
        Blue,
        [Description("R")]
        Red
    }

    internal enum Rank
    {
        [Description("1")]
        One,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four,
        [Description("5")]
        Five,
        [Description("6")]
        Six,
        [Description("7")]
        Seven,
        [Description("8")]
        Eight,
        [Description("9")]
        Nine,
        [Description("10")]
        Ten
    }

    internal static class EnumExtension
    {
        public static string Description(this Suit suit)
        {
            return Utils.EnumExtension.GetDescription(suit);
        }

        public static string Description(this Rank rank)
        {
            return Utils.EnumExtension.GetDescription(rank);
        }
    }
}
