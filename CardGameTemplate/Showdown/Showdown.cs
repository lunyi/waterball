using CardGame.Common;

namespace CardGame.Showdown
{
    internal class Showdown : Game<Card>
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

        private const int Card_Count = 13;

        public Showdown(Deck deck, Player[] players) : base(deck, players)
        {

        }

        public override void Start() 
        {
            initPlayerCards(Card_Count);
            runAllRounds();
            displayWinner();
        }

        private void runAllRounds()
        {
            for (int i = 0; i < Card_Count; i++)
            {
                Console.WriteLine("====================");
                Console.WriteLine($"Round-{i+1}");
                Console.WriteLine();
                Thread.Sleep(100);
                var rounds = new List<Round>();
                foreach (var player in _players)
                {
                    Console.WriteLine($"{player.Name}");
                    var cards = player.Hand.ShowCards();
                    foreach (var c in cards)
                    {
                        displayCard(c);
                    }
                    var showdownPlayer = player as Player;
                    var card = showdownPlayer.SelectCard();
                    
                    if (card != null)
                    {
                        displayCard(card, "==>");
                        Console.WriteLine();
                        
                        rounds.Add(new Round(showdownPlayer, card));
                    }
                }
                
                compareCard(rounds.ToArray());
            }
        }

        private void displayCard(Card card, string targetSymbol = "")
        {
            Console.Write($" {targetSymbol} {MapRank[card.Rank]}{MapSuit[card.Suit]} ");
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
            var players = _players.OfType<Player>().ToArray();

            var (winners, point) = players.GetFinalWinner();

            var winnerString = string.Join(", ", winners);
            var result = $"(The Winner is {winnerString} and the point is {point})\n";
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public override Player<Card>[] GetPlayers()
        {
            return _players;
        }
    }
}
