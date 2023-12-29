using System.Reflection.Metadata;
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

            var quit = false;
            while (!quit)
            {
                DrawCards.DisplayCardsOfPlayers(_players);
                Thread.Sleep(100);
                RunEachRound(_players);
            }
            RountCount = 13;
            Console.ReadKey();
        }


        private void RunEachRound(IList<Player> players)
        {
            while (RountCount <= Num_Of_Ranks)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    var descision = players[i].MakeExchangeHandsDecision(players);
                    if (descision) 
                    {
                        players[i].OnDrawPlayerCards += OnDrawPlayerCards;
                        DrawCards.DisplayCardsOfPlayers(players);
                    }
                }

                for (int i = 0; i < players.Count; i++)
                {
                    players[i].TakeTurn();
                }

                Console.WriteLine();
                var handsInThisRound = players.Select(p => p._hand).ToList();
                DrawCards.DisplayRound(handsInThisRound);
                (Player winner, IList<IHand> rounds) = GetWinner(handsInThisRound);

                winner.AddPoint();
                Console.WriteLine();
                Thread.Sleep(200);
                Console.WriteLine();

                var result = $"(The Winner of this round is {winner.GetPlayerName()})\n";

                for (int j = 0; j < rounds.Count; j++)
                {
                    var player = rounds[j].GetPlayer();
                    result += $"{player.GetPlayerName()}: {player.GainPoint()} points\n";
                }

                Console.WriteLine(result);

                Console.ReadKey();
                Console.Clear();
                DrawCards.DisplayCardsOfPlayers(players);
                RountCount--;
            }
        }

        private (Player winner, IList<IHand> rounds) GetWinner(List<IHand> hands)
        {
            IList<IHand> sortedHands = hands.ToList(); // Create a copy to avoid modifying the original list

            for (int i = 0; i < sortedHands.Count; i++)
            {
                for (int j = 0; j < sortedHands.Count - 1; j++)
                {
                    if (sortedHands[j + 1].ShowCard().CompareTo(sortedHands[j].ShowCard()) > 0)
                    {
                        (sortedHands[j], sortedHands[j + 1]) = (sortedHands[j + 1], sortedHands[j]);
                    }
                }
            }

            return (sortedHands[0].GetPlayer(), sortedHands);
        }

        private void OnDrawPlayerCards(object? sender, EventArgs e)
        {
            var players = sender as IList<Player>;
            DrawCards.DisplayCardsOfPlayers(players);
        }

        private void InitPlayerCards()
        {
            foreach (var player in _players)
            {
                for (int i = 0; i < Num_Of_Ranks; i++)
                {
                    player.AddHandCard(_deck.DrawCard());
                }
            }
        }       
    }
}
