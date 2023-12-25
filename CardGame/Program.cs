using System.Text;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.OutputEncoding = Encoding.UTF8;
            DrawCards.DrawCardOutline(0, 0);

            Card card = new Card(Suit.Heart,Rank.Ace);

            DrawCards.DrawCardSuitValue(card, 0, 0);

            Console.ReadKey();
        }
    }
}