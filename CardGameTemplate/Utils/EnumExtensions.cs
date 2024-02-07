using CardGame.Showdown;
using System.ComponentModel;
using System.Reflection;
using UnoSuit = CardGame.Uno.Suit;
using UnoRank = CardGame.Uno.Rank;

namespace CardGame.Utils
{
    internal static class EnumExtension
    {
        public static string Description(this Suit suit)
        {
            return GetDescription(suit);
        }

        public static string Description(this Rank rank)
        {
            return GetDescription(rank);
        }

        public static string Description(this UnoSuit suit)
        {
            return GetDescription(suit);
        }

        public static string Description(this UnoRank rank)
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
}
