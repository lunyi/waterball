using System.Numerics;
using System.Xml.Serialization;

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
                decidePlayersOrder();
                RunEachRound();
            }
           
            Console.ReadKey();
        }

        private void RunEachRound()
        {
            List<Card> showcards = null;
            var isReShowCard = false;
            var passCount = 0;

            while (true)
            {
                for (int i = 0; i < _orderedPlayers.Count; i++) 
                {
                    Console.WriteLine();
                   
                    if (isReShowCard || Round == 0)
                    {
                        showcards = showFirstCards(_orderedPlayers[i]);
                        isReShowCard = false;
                        passCount = 0;
                        Round++;
                    }
                    else
                    {
                        var tmp = showCards(_orderedPlayers[i], showcards, ref passCount);
                        if (tmp != null && tmp.Count > 0)
                        {
                            showcards = tmp;
                        }
                    }

                    if (_orderedPlayers[i].ShowCards().Count == 0)
                    {
                        Console.WriteLine($"遊戲結束，遊戲的勝利者為 {_orderedPlayers[i].Name}");
                        Environment.Exit(0);
                    }

                    if (passCount == 3)
                    {
                        isReShowCard = true;
                    }
                }

                Console.ReadKey();
                Round++;
            }
        }

        private List<Card> showCards(Player player, List<Card> cards, ref int pass)
        {
            displayCards(player);
            var showcards = player.ShowCards(cards);
            if (showcards == null || showcards.Count == 0)
            {
                Console.WriteLine($"玩家 {player.Name} PASS.");
                pass++;
            }
            else
            {
                showcards.Display();
                pass = 0;
            }
            return showcards;
        }

        private List<Card> showFirstCards(Player player) 
        {
            Console.WriteLine($"新的回合開始了。");
            displayCards(player);
            var showcards = player.ShowFirstCards();

            if (showcards == null)
            {
                Console.WriteLine($"玩家 {player.Name} PASS.");
            }
            else
            {
                showcards.Display();
            }
            return showcards;
        }
        private void displayCards(Player player)
        {
            var cards = player.ShowCards();
            player.DisplayTurn();
            cards.Display(true);
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
                    if (sortedHands[j + 1].ShowCard().GreatThan(sortedHands[j].ShowCard()))
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
