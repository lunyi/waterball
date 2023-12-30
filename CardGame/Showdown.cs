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
                InitPlayerCards();
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
                PlayerMakeExchangeHandsDecision(players);
                PlayerTakeTurn(players);

                var handsInThisRound = GetHandsInThisRound(players);

                DrawCards.DisplayRound(handsInThisRound);

                (Player winner, IList<IHand> rounds) = GetWinner(handsInThisRound);

                winner.AddPoint();
                DrawCards.DisplayRoundWinnner(winner, rounds);
                Console.ReadKey();
                Console.Clear();

                PlayerChangeHandBack(players);
                DrawCards.DisplayCardsOfPlayers(players);
                RountCount--;
            }
        }


        private List<IHand> GetHandsInThisRound(IList<Player> players)
        { 
            return players.Select(p => p._hand).ToList();
        }
        private void PlayerMakeExchangeHandsDecision(IList<Player> players)
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
        private void PlayerTakeTurn(IList<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].TakeTurn();
            }
        }

        private void PlayerChangeHandBack(IList<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].IsChangeBack())
                {
                    players[i].ChangeHandBack();
                }
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

        private void InitPlayerCards()
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
