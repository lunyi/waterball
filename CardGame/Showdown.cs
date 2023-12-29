using System.Text;

namespace CardGame
{
    internal class Showdown
    {
        private const int Num_Of_Ranks = 13;
        private int RountCount = 13;
        private IDeck _deck;
        private IList<Player> _players;
        public Showdown(IDeck deck, IList<Player> players)
        {
            _deck = deck;
            _players = players;
        }
        public void Start() 
        {
            InitPlayerCards();
            Console.ForegroundColor = ConsoleColor.White;
            //Console.SetWindowSize(130, 300);
            Console.OutputEncoding = Encoding.UTF8;

            var quit = false;
            while (!quit)
            {
                DrawCardsOfPlayers(_players);
                Thread.Sleep(100);
                RunRound(_players);
            }
            RountCount = 13;
            Console.ReadKey();
        }

        private void RunRound(IList<Player> players)
        {
            while (RountCount <= Num_Of_Ranks)
            {
                for (int i = 0; i <= players.Count; i++)
                {
                    players[i].makeExchangeHandsDecision(players);
                }

                for (int i = 0; i <= players.Count; i++)
                {
                    players[i].TakeTurn();
                }

                Console.WriteLine();
                var handsInThisRound = players.Select(p => p.Hand).ToList();
                DrawRound(handsInThisRound);
                (Player winner, List<Hand> rounds) = GetWinner(handsInThisRound);

                winner.AddPoint();
                Console.WriteLine();
                Thread.Sleep(200);
                Console.WriteLine();

                var result = $"(The Winner of this round is {winner.GetPlayerName()})\n";

                for (int j = 0; j < rounds.Count; j++)
                {
                    var player = rounds[j].Player;
                    result += $"{player.GetPlayerName()}: {player.GainPoint()} points\n";
                }

                Console.WriteLine(result);

                Console.ReadKey();
                Console.Clear();
                DrawCardsOfPlayers(players);
                RountCount--;
            }
        }
   
        private (Player Winner, List<Hand> SortedHands) GetWinner(List<Hand> hands)
        {
            List<Hand> sortedHands = hands.ToList(); // Create a copy to avoid modifying the original list

            for (int i = 0; i < sortedHands.Count; i++)
            {
                for (int j = 0; j < sortedHands.Count - 1; j++)
                {
                    if (sortedHands[j + 1].CurrentCard.Showdown(sortedHands[j].CurrentCard) > 0)
                    {
                        (sortedHands[j], sortedHands[j + 1]) = (sortedHands[j + 1], sortedHands[j]);
                    }
                }
            }

            return (sortedHands[0].Player, sortedHands);
        }

        private void DrawRound(List<Hand> hands)
        {
            Console.WriteLine();
            Console.WriteLine();
            var initialCursorTop = Console.CursorTop;

            for (int i = 0; i < hands.Count; i++)
            {
                Console.Write("  ");
                DrawCards.DrawCardOutline(i, initialCursorTop + 1);
                DrawCards.DrawCardSuitValue(hands[i].CurrentCard, i, initialCursorTop + 1);
            }
            Thread.Sleep(500);
            Console.WriteLine();

            for (int i = 0; i < hands.Count; i++)
            {
                Console.ForegroundColor = hands[i].Player is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.White;
                Console.Write(" " + hands[i].Player.GetPlayerName() + "  ");
            }
        }

        private void InitPlayerCards()
        {
            foreach (var player in _players)
            {
                for (int i = 0; i < 13; i++)
                {
                    player.AddHandCard(_deck.DrawCard());
                }
            }
        }
        private void DrawCardsOfPlayers(IList<Player> players)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.White;
            var y = 2;
            for (int i = players.Count - 1; i >= 0; i--)
            {
                var cards = players[i].ShowCards();

                Console.SetCursorPosition(0, y);
                Console.ForegroundColor = players[i] is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.Yellow;

                Console.WriteLine(players[i].GetPlayerName());

                for (int j = 0; j < cards.Length; j++)
                {
                    Thread.Sleep(100);
                    var c = new Card(cards[j].Suit, cards[j].Rank);
                    DrawCards.DrawCardOutline(j, y + 1);
                    DrawCards.DrawCardSuitValue(c, j, y + 1);
                }
                y = y + 7;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int j = 0; j < RountCount; j++)
            {
                Console.Write($"{(j < 10 ? "   " : "  ")}{j + 1}{(j < 10 ? "    " : "   ")}");
            }
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine();
        }
    }
}
