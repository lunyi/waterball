namespace Game
{
    internal class PlayerGenerator
{
        public static IList<Player> GetPlayers(string playername, int playerCount)
        {
            var players = new List<Player>();
            var aiPlayerNames = GetAIPlayerNames(playerCount);

            for (int i = 1; i < playerCount; i++)
            {
                var aip = new AIPlayer(i);
                aip.Naming(aiPlayerNames[i]);
                players.Add(aip);
            }

            var p = new HumanPlayer(4);
            p.Naming(playername);
            players.Add(p);
            return players;
        }
        private static string[] GetAIPlayerNames(int playerCount)
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
