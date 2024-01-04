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
                DisplayCards.DisplayCardsOfPlayers(_players);
                Thread.Sleep(100);
                RunEachRound();
            }
           
            Console.ReadKey();
        }

        private void RunEachRound()
        {
            while (RountCount >= 1 && RountCount <= Num_Of_Ranks)
            {
                checkIfPlayerWantToExchangeCard();

                var handsInThisRound = playersDrawCard();
                DisplayCards.DisplayRound(handsInThisRound);

                (Player winner, List<Hand> rounds) = getRoundWinner(handsInThisRound);

                winner.AddPoint();
                DisplayCards.DisplayRoundWinnner(winner, rounds);
                Console.ReadKey();
                Console.Clear();

                checkPlayerChangeHandBack();
                displayCardsOfPlayers();
            }
            displayWinner();
        }

        private void displayWinner()
        {
            Console.WriteLine();
            var (winners, point) = _players.GetFinalWinner();

            var winnerString = string.Join(", ", winners);
            var result = $"(The Winner is {winnerString} and the point is {point})\n";
            Console.WriteLine(result);
            Console.ReadKey();
        }
        private void displayCardsOfPlayers()
        {
            if (RountCount >= 2)
            {
                DisplayCards.DisplayCardsOfPlayers(_players);
            }
            RountCount--;
        }

        private void checkIfPlayerWantToExchangeCard()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                var descision = _players[i].ExchangeHands.CheckIfPlayerWantToExchangeCard(_players[i], _players);
                if (descision)
                {
                    DisplayCards.DisplayCardsOfPlayers(_players);
                }
            }
        }

        private List<Hand> playersDrawCard()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].DrawCard();
            }
            return _players.Select(p => p.Hand).ToList();
        }

        private void checkPlayerChangeHandBack()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ExchangeHands.ChangeHandBack();
            }
        }

        private (Player winner, List<Hand> rounds) getRoundWinner(List<Hand> hands)
        {
            List<Hand> sortedHands = hands.ToList(); // Create a copy to avoid modifying the original list

            for (int i = 0; i < sortedHands.Count; i++)
            {
                for (int j = 0; j < sortedHands.Count - 1; j++)
                {
                    if (sortedHands[j + 1].ShowCard().GreatThen(sortedHands[j].ShowCard()))
                    {
                        (sortedHands[j], sortedHands[j + 1]) = (sortedHands[j + 1], sortedHands[j]);
                    }
                }
            }

            return (sortedHands[0].Player, sortedHands);
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
