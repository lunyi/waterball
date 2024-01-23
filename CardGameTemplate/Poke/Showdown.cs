using CardGame.Common;

namespace CardGame.Poke
{
    internal class Showdown
    {
        private Dictionary<Suit, string> MapSuit = new Dictionary<Suit, string> 
        {
            { Suit.Heart, "H"},
            { Suit.Diamond, "D"},
            { Suit.Spade, "S"},
            { Suit.Club, "C"}
        };

        private Dictionary<Rank, string> MapRank = new Dictionary<Rank, string>
        {
            { Rank.Ace, "A"},
            { Rank.Two, "2"},
            { Rank.Three, "3"},
            { Rank.Four, "4"},
            { Rank.Five, "5"},
            { Rank.Six, "6"},
            { Rank.Seven, "7"},
            { Rank.Eight, "8"},
            { Rank.Nine, "9"},
            { Rank.Ten, "X"},
            { Rank.Jack, "J"},
            { Rank.Queen, "Q"},
            { Rank.King, "K"},
        };

        private const int Num_Of_Ranks = 13;
        private IDeck<Suit, Rank> _deck;
        private Player[] _players;

        public Showdown(IDeck<Suit, Rank> deck, Player[] players)
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
                        Console.Write($" {MapRank[(Rank)c.Rank]}{MapSuit[(Suit)c.Suit]} ");
                    }

                    var card = player.SelectCard();
                    
                    if (card != null)
                    {
                        Console.Write($" ==> {MapRank[(Rank)card.Rank]}{MapSuit[(Suit)card.Suit]} ");
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
            Console.WriteLine($"round winner: {round.Player.Name} {MapRank[maxCard.Rank]}{MapSuit[maxCard.Suit]}");
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
