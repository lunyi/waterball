using System.Text;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(130, 30);
            Console.OutputEncoding = Encoding.UTF8;

            DrawCards.DrawCardOutline(0, 0);
            Card card = new Card(Suit.Heart, Rank.Ace);
            DrawCards.DrawCardSuitValue(card, 0, 0);

            Card card2 = new Card(Suit.club, Rank.Two);
            DrawCards.DrawCardOutline(1, 0);
            DrawCards.DrawCardSuitValue(card2, 1, 0);



            //for (int i = 0; i < 130; i++)
            //{
            //    for (int j = 0; j < 30; j++)
            //    {
            //        Console.SetCursorPosition(i, j);
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.Write($"{i},{j}");
            //    }
            //}


            var quit = false;

            while (!quit)
            {
                Console.WriteLine("What's your name?");
                string? name = Console.ReadLine();
                var p = new HumanPlayer();
                p.NameHimself(name.);
            }

            

            Console.ReadKey();
        }
    }
}