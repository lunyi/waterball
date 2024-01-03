using Game.Card;
using Game.Players;

namespace Game.Uno
{
    internal class DisplayUno
    {
        static Dictionary<SuitUno, ConsoleColor> MapSuit = new Dictionary<SuitUno, ConsoleColor>
            {
                { SuitUno.Blue,ConsoleColor.Blue },
                { SuitUno.Yellow,ConsoleColor.Yellow },
                { SuitUno.Green,ConsoleColor.Green },
                { SuitUno.Red,ConsoleColor.Red },
            };

        static Dictionary<RankUno, string> MapRank = new Dictionary<RankUno, string>
            {
                { RankUno.Zero, "0" },
                { RankUno.One, "1" },
                { RankUno.Two, "2" },
                { RankUno.Three, "3" },
                { RankUno.Four, "4" },
                { RankUno.Five, "5" },
                { RankUno.Six, "6" },
                { RankUno.Seven, "7" },
                { RankUno.Eight, "8" },
                { RankUno.Nine, "9" }
            };

        internal static void DisplayCardsOfPlayers(IList<Player> players, int topPosition)
        {
            for (int i = 0; i < players.Count; i++)
            {
                var cards = players[i].UnoHand.GetCards();
                Console.SetCursorPosition(0, topPosition);
                Console.ForegroundColor = players[i] is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.WriteLine($"{players[i].Index}: {players[i].Name}");

                for (int j = 0; j < cards.Length; j++)
                {
                    var c = new Card<RankUno, SuitUno>(cards[j].Suits, cards[j].Ranks);
                    DisplayUno.DrawCard(c, 2 * j, topPosition + 1);
                    Console.ResetColor();
                }
                topPosition = topPosition + 7;
            }

        }
        internal static void DisplayRound(List<IUnoHand> hands)
        {
            var initialCursorTop = Console.CursorTop;

            for (int i = 0; i < hands.Count; i++)
            {
                Console.Write("  ");

                //DrawCard(i, initialCursorTop + 1);
            }
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //for (int i = 0; i < hands.Count; i++)
            //{
            //    var player = hands[i].GetPlayer();
            //    Console.ForegroundColor = player is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.White;
            //    Console.Write(" " + player.Name + "  ");
            //}
            Console.ForegroundColor = ConsoleColor.White;
        }


        internal static void DrawCard(Card<RankUno, SuitUno> card, int xcoor, int ycoor)
        {
            int x = xcoor * 8;
            int y = ycoor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("_______\n");
            Console.BackgroundColor = MapSuit[card.Suits];

            for (int i = 0; i < 5; i++) 
            {
                Console.SetCursorPosition(x, y+1+i);
                if (i == 2)
                {
                    DrawMiddleRow(card);
                }
                else if (i == 4)
                {
                    Console.Write($"|______|");
                }
                else {
                    Console.Write($"|      |");
                }
            }
        }

        private static void DrawMiddleRow(Card<RankUno, SuitUno> card)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"|  {MapRank[card.Ranks]}   |");
        }
    }
}
