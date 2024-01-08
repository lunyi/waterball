using System.Text;

namespace CardGame
{
    internal class Program
    {
        private const int playerCount = 4 ;
        static void Main(string[] args)
        {

            var cards = new List<Card>
            { 
                new Card(Suit.Club, Rank.Three),
                new Card(Suit.Club, Rank.Four),
                new Card(Suit.Club, Rank.Five),
                new Card(Suit.Club, Rank.King),
                new Card(Suit.Club, Rank.Six),
                new Card(Suit.Diamond, Rank.Three),
                new Card(Suit.Diamond, Rank.Four),
                new Card(Suit.Diamond, Rank.Five),
                new Card(Suit.Diamond, Rank.King),
                new Card(Suit.Diamond, Rank.Six),
                new Card(Suit.Spade, Rank.Three),
                new Card(Suit.Spade, Rank.Seven),
                new Card(Suit.Spade, Rank.Ten)
            };

            var tmp = cards.GetSingle(new Card(Suit.Club, Rank.Four));

            InitConsoleSetting();
            IDeck deck = new Deck();
            IList<Player> players = GetPlayers("lester");

            var showdown = new Game(deck, players);
            showdown.Start();
        }

        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.SetWindowSize(130, 100);
            Console.OutputEncoding = Encoding.UTF8;
        }

        private static IList<Player> GetPlayers(string playername)
        {
            var players = new List<Player>();
            var aiPlayerNames = GetAIPlayerNames();

            for (int i = 1; i <= playerCount; i++)
            {
                var aip = new AIPlayer(i);
                aip.Naming(aiPlayerNames[i]);
                players.Add(aip);
            }
            return players;
        }
        private static string[] GetAIPlayerNames()
        {
            string[] englishNames = {
            "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Henry", "Ivy", "Jack",
            "Katherine", "Leo", "Mia", "Nathan", "Olivia", "Paul", "Quinn", "Ryan", "Sophie", "Tom"
        };

            var random = new Random();
            var names = new List<string>();
            while (names.Count <= playerCount)
            {
                int randomIndex = random.Next(englishNames.Length);
                string randomName = englishNames[randomIndex];

                if (!names.Contains(randomName))
                {
                    names.Add(randomName);
                }
            }
            return names.ToArray();
        }
    }
}