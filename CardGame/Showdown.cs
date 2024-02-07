using System.Numerics;

namespace CardGame
{
    internal class Showdown
    {
        private const int Num_Of_Ranks = 13;
        private IDeck _deck;
        private Player[] _players;

        public Showdown(IDeck deck, Player[] players)
        {
            _deck = deck;
            _players = players;
        }

        public Player[] GetPlayers()
        {
            return _players;
        }

        public void Start() 
        {
            initPlayerCards();
            runAllRounds();
            displayWinner();
        }

        private void runAllRounds()
        {
            for (int i = 0; i < Num_Of_Ranks; i++)
            {
                Console.WriteLine("====================");
                Console.WriteLine($"Round-{i+1}");
                var rounds = new List<Round>();
                foreach (var player in _players)
                {
                    Console.WriteLine($"{player.Name}");
                    var cards = player.Hand.ShowCards();
                    foreach (var c in cards)
                    { 
                        Console.Write($" [{c.Rank.Description()}]{c.Suit.Description()} ");
                    }

                    var card = player.SelectCard();
                    
                    if (card != null)
                    {
                        Console.Write($" ==> [{card.Rank.Description()}]{card.Suit.Description()} ");
                        Console.WriteLine();
                        rounds.Add(new Round(player, card));
                    }
                }
                
                compareCard(rounds.ToArray());
            }
        }

        private void compareCard(Round[] rounds)
        {
            var maxCard = rounds.Max(p => p.Card);
            var round = rounds.FirstOrDefault(p => p.Card == maxCard);
            round.Player.AddPoint();
            Console.WriteLine($"round winner: {round.Player.Name} {maxCard.Rank.Description()}{maxCard.Suit.Description()}");
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

        private void initPlayerCards()
        {
            foreach (var player in _players)
            {
                player.Naming();
                player.Showdown = this;
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
