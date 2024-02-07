
using CardGame.Base;
using CardGame.Utils;

namespace CardGame.Uno
{
    internal class DisplayUno
    {
        static Dictionary<Suit, ConsoleColor> MapSuit = new Dictionary<Suit, ConsoleColor>
            {
                { Suit.Blue,ConsoleColor.Blue },
                { Suit.Yellow,ConsoleColor.Yellow },
                { Suit.Green,ConsoleColor.Green },
                { Suit.Red,ConsoleColor.Red },
            };

        internal static void DisplayAllCards(Card[] cards)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (var card in cards)
            {
                Console.BackgroundColor = MapSuit[card.Suit];
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($" {card.Rank.Description()} ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        internal static int DisplayCardsOfPlayers(IList<Player<Card>> players)
        {
            var topPosition = 2;
            Console.Clear();
            for (int i = 0; i < players.Count; i++)
            {
                var cards = players[i].Hand.ShowCards();
                Console.SetCursorPosition(0, topPosition);
                Console.ForegroundColor = players[i] is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.WriteLine($"{players[i].Index}: {players[i].Name}");

                for (int j = 0; j < cards.Length; j++)
                {
                    var c = new Card(cards[j].Suit, cards[j].Rank);
                    if (j <= 5)
                    {
                        Thread.Sleep(100);
                        DrawCard(c, j, topPosition + 1);
                    }
                    
                    Console.ResetColor();
                }
                topPosition = topPosition + 7;
            }
            return topPosition;
        }

        internal static void DrawCard(Card card, int xcoor, int ycoor)
        {
            if (card == null)
            {
                return;
            }
            int x = xcoor * 8;
            int y = ycoor;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = MapSuit[card.Suit];
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" {card.Rank.Description()} ");
            Console.ResetColor();
        }
    }
}
