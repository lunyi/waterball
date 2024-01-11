using System.Text;

namespace CardGame
{
    internal class Program
    {
        private const int playerCount = 4 ;
        static void Main(string[] args)
        {
            InitConsoleSetting();
            IDeck deck = new Deck();
            IList<Player> players = PlayerGenerator.GetPlayers("lester", playerCount);

            var showdown = new Showdown(deck, players);
            showdown.Start();
        }

        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}