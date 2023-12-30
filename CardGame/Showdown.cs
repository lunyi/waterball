using System.Reflection;
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
            var quit = false;
            while (!quit)
            {
                initPlayerCards();
                DrawCards.DisplayCardsOfPlayers(_players);
                Thread.Sleep(100);
                RunEachRound(_players);
            }
           
            Console.ReadKey();
        }


        private void RunEachRound(IList<Player> players)
        {
            while (RountCount >= 1 && RountCount <= Num_Of_Ranks)
            {
                playerMakeExchangeHandsDecision(players);
                playerTakeTurn(players);


                var handsInThisRound = getHandsInThisRound(players);

                DrawCards.DisplayRound(handsInThisRound);

                (Player winner, IList<IHand> rounds) = getWinner(handsInThisRound);

                winner.AddPoint();
                DrawCards.DisplayRoundWinnner(winner, rounds);
                Console.ReadKey();
                Console.Clear();

                playerChangeHandBack(players);
                finadResult(players);
            }
        }

        private void finadResult(IList<Player> players)
        {
            if (RountCount >= 2)
            {
                DrawCards.DisplayCardsOfPlayers(players);
            }
            else
            {
                Console.WriteLine();
                var (winners, point) = players.GetFinalWinner();

                var winnerString = string.Join(", ", winners);
                var result = $"(The Winner is {winnerString} and the point is {point})\n";
                Console.WriteLine(result);
                Console.ReadKey();
            }
            RountCount--;
        }

        private List<IHand> getHandsInThisRound(IList<Player> players)
        { 
            return players.Select(p => p.Hand).ToList();
        }
        private void playerMakeExchangeHandsDecision(IList<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                var descision = players[i].MakeExchangeHandsDecision(players);
                if (descision)
                {
                    DrawCards.DisplayCardsOfPlayers(players);
                }
            }
        }
        private void playerTakeTurn(IList<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].TakeTurn();
            }
        }

        private void playerChangeHandBack(IList<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].IsChangeBack())
                {
                    players[i].ChangeHandBack();
                }
            }
        }

        private (Player winner, IList<IHand> rounds) getWinner(List<IHand> hands)
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

        private void initPlayerCards()
        {
            RountCount = Num_Of_Ranks;
            foreach (var player in _players)
            {
                player.Clear();
            }

            _deck.Shuffle();

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
