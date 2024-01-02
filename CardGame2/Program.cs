using System.Text;

namespace Game
{
    internal class Program
    {
        private const int playerCount = 4 ;
        static void Main(string[] args)
        {
            InitConsoleSetting();
            var cardDeck = new Deck<Card<Rank, Suit>, Rank, Suit>();
            var unoDeck = new Deck<UnoCard, RankUno, SuitUno>();

            IList<Player> players = PlayerGenerator.GetPlayers("lester", playerCount);

            var nno = new UnoGame(unoDeck, players);
            nno.Start();
        }

        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.SetWindowSize(130, 100);
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}