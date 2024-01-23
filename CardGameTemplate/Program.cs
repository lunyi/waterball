using CardGame.Common;
using CardGame.Poke;
using System.Text;
//using CardGame.Uno;

namespace Game
{
    internal class Program
    {
        private const int playerCount = 4 ;

        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(130, 600);
            Console.OutputEncoding = Encoding.UTF8;
        }

        static void Main(string[] args)
        {
            InitConsoleSetting();
            var deck = new Deck<Suit, Rank>();
            var players = new Player<Suit, Rank>[] { new HumanPlayer<Suit, Rank>(1), new AIPlayer<Suit, Rank>(2), new AIPlayer<Suit, Rank>(3), new AIPlayer<Suit, Rank>(4) };

            //var unoGame = new UnoGame(deck, players);
            //unoGame.Start();


            //IDeck deck = new Deck();
            //var players = new Player[] { new HumanPlayer(1), new AIPlayer(2), new AIPlayer(3), new AIPlayer(4) };

            var showdown = new Showdown(deck, players);
            showdown.Start();

        }
    }
}