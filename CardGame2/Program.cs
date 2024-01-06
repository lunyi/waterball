using Game.Players;
using Game.Uno;
using Game.Card;
using System.Text;

namespace Game
{
    internal class Program
    {
        private const int playerCount = 4 ;
        static void Main(string[] args)
        {
            InitConsoleSetting();
            var players = PlayerGenerator.GetPlayers("lester", playerCount);

            //var cardDeck = new Deck<Card.Card<Rank, Suit>, Rank, Suit>();
            //var game = new Showdown(cardDeck, players);
            //game.Start();

            var unoDeck = new Deck<Uno.Card<RankUno, SuitUno>, RankUno, SuitUno>();
            var game = new UnoGame(unoDeck, players);
            game.Start();
        }

        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.SetWindowSize(130, 600);
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}