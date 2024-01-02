using Game.Uno;
using System.Text;

namespace Game
{
    internal class Program
    {
        private const int playerCount = 4 ;
        static void Main(string[] args)
        {
            InitConsoleSetting();
            var players = PlayerGenerator.GetPlayers("lester", 4);

            //var cardDeck = new Deck<Card<Rank, Suit>, Rank, Suit>();
            //var game = new Showdown(cardDeck, players);
            //game.Start();

            var unoDeck = new Deck<Uno.Card<RankUno, SuitUno>, RankUno, SuitUno>();
            var game = new UnoGame(unoDeck, players);
            game.Start();
        }

        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.SetWindowSize(130, 100);
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}