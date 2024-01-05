namespace CardGame
{
    internal class DisplayCards
    {
        internal static void DisplayRound(List<Hand> hands)
        {
            var initialCursorTop = Console.CursorTop;

            for (int i = 0; i < hands.Count; i++)
            {
                Console.Write("  ");
                DrawCardOutline(i, initialCursorTop + 1);
                DrawCardSuitValue(hands[i].ShowCard(), i, initialCursorTop + 1);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < hands.Count; i++)
            {
                var player = hands[i].Player;
                Console.ForegroundColor = player is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.White;
                Console.Write(" " + player.Name + "  ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void DisplayRoundWinnner(Player winner, List<Hand> rounds)
        {
            Console.WriteLine();
            var result = $"(The Winner of this round is {winner.Name})\n";

            Console.WriteLine();
            for (int j = 0; j < rounds.Count; j++)
            {
                var player = rounds[j].Player;
                result += $"{player.Name}: {player.GetPoint()} points\n";
            }

            Console.WriteLine(result);
        }

        internal static void DisplayCardsOfPlayers(IList<Player> players) 
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Round:{14 - players[0].ShowCards().Length} / 13");

            var topPosition = 2;
            for (int i = 0; i < players.Count; i++)
            {
                var cards = players[i].ShowCards();

                Console.SetCursorPosition(0, topPosition);
                Console.ForegroundColor = players[i] is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.Yellow;
                Console.WriteLine($"{players[i].Index}: {players[i].Name}");

                for (int j = 0; j < cards.Length; j++)
                {
                    var c = new Card(cards[j].Suit, cards[j].Rank);
                    DrawCardOutline(j, topPosition + 1);
                    DrawCardSuitValue(c, j, topPosition + 1);
                }
                topPosition = topPosition + 7;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int j = 0; j < players[0].ShowCards().Length; j++)
            {
                Console.Write($"{(j < 10 ? "   " : "  ")}{j + 1}{(j < 10 ? "    " : "   ")}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void DrawCardOutline(int xcoor, int ycoor)
        { 
            Console.ForegroundColor = ConsoleColor.White;
            int x = xcoor * 8;
            int y = ycoor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("_______\n");

            for (int i = 0; i < 5; i++) 
            {
                Console.SetCursorPosition(x, y+1+i);
                Console.Write($"{(i != 4 ? "|      |" : "|______|")}");
            }
        }

        internal static void DrawCardSuitValue(Card card, int xcoor, int ycoor) 
        {
            char cardSuit = ' ';
            int x = xcoor * 8 +1 ;
            int y = ycoor;

            switch (card.Suit)
            {
                case Suit.Heart:
                    cardSuit = '\u2665';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.Diamond:
                    cardSuit = '\u2666';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.Club:
                    cardSuit = '\u2663';
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Suit.Spade:
                    cardSuit = '\u2660';
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.SetCursorPosition(x, y + 1);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x+1, y+3);
            Console.Write(card.Rank);
        }
    }
}
