using System.ComponentModel;
using System.Reflection;

namespace CardGame.Showdown
{
    internal class Card : IComparable<Card>
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int CompareTo(Card? other)
        {
            int rankComparison = Rank.CompareTo(other.Rank);
            if (rankComparison != 0)
            {
                return rankComparison;
            }
            return Suit.CompareTo(other.Suit);
        }
    }
 

    internal enum Suit
    {
        [Description("C")]
        Club,
        [Description("D")]
        Diamond,
        [Description("H")]
        Heart,
        [Description("S")]
        Spade
    }

    internal enum Rank
    {
        [Description("2")]
        Two = 2,
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
        Ten,
        [Description("J")]
        Jack,
        [Description("Q")]
        Queen,
        [Description("K")]
        King,
        [Description("A")]
        Ace
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
