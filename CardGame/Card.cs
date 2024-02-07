using System.ComponentModel;
using System.Reflection;

namespace CardGame
{
    internal class Card : IComparable
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        { 
            Rank = rank;
            Suit = suit;
        }

        public int CompareTo(object? obj)
        {
            var card = obj as Card;
            int rankComparison = Rank.CompareTo(card.Rank);
            if (rankComparison != 0)
            {
                return rankComparison;
            }
            return Suit.CompareTo(card.Suit);
        }

        public List<Card> GenerateCards()
        {
            var generatedCards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    generatedCards.Add(new Card(suit, rank));
                }
            }
            return generatedCards;
        }
    }

    internal static class EnumExtension
    {
        public  static string Description(this Suit suit)
        {
            return GetDescription(suit);
        }

        public  static string Description(this Rank rank)
        {
            return GetDescription(rank);
        }

        private static string GetDescription<T>(this T enumValue) where T : Enum
        {
            Type enumType = typeof(T);
            string name = enumValue.ToString();
            var field = enumType.GetField(name);
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? name;
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
}
