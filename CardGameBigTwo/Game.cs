namespace CardGame
{
    internal class Game
    {
        private const int Num_Of_Ranks = 13;
        private int RountCount = 13;
        private IDeck _deck;
        private IList<Player> _players;
        private List<Player> _orderedPlayers;
        private int Round = 0;

        public Game(IDeck deck, IList<Player> players)
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
                Console.WriteLine("新的回合開始了。");
                Thread.Sleep(100);
                RunEachRound();
            }
           
            Console.ReadKey();
        }

        private void RunEachRound()
        {
            while (true)
            {
                if (Round == 0)
                {
                    decidePlayersOrder();
                }
                
                for (int i = 0; i < _orderedPlayers.Count; i++) 
                {
                    var cards = _orderedPlayers[i].ShowCards();
                    _orderedPlayers[i].DisplayTurn();
                    cards.Display();
                    Console.ReadLine();
                }


                Console.ReadKey();
                Console.Clear();
            }
            displayWinner();
        }

        private void decidePlayersOrder()
        {
            var player = _players.First(p => p.ShowCards().ContainClub3());
            _players.SetPlayersOrder(player.Index);
            _orderedPlayers = _players.OrderBy(p => p.OrderIndex).ToList();
        }
        private void displayWinner()
        {
            Console.WriteLine();
            //var (winners, point) = _players.GetFinalWinner();

            //var winnerString = string.Join(", ", winners);
            //var result = $"(The Winner is {winnerString} and the point is {point})\n";
            //Console.WriteLine(result);
            Console.ReadKey();
        }

        private List<Hand> playersDrawCard()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].DrawCard();
            }
            return _players.Select(p => p.Hand).ToList();
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
