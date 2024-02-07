using CardGame.Base;
using CardGame.Utils;

namespace CardGame.Showdown
{
    internal class Showdown : Game<Card>
    {
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
            Console.Write($" {targetSymbol} {card.Rank.Description()}{card.Suit.Description()} ");
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
