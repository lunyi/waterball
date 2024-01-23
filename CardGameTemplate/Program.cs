using CardGame.Poke;
using CardGame.Uno;
using System.Text;
using CardGame.Poke;
using Player = CardGame.Poke.Player;
using HumanPlayer = CardGame.Poke.HumanPlayer;
using AIPlayer = CardGame.Poke.AIPlayer;
using CardGame.Common;
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
            var deck = new Deck<CardGame.Poke.Suit, CardGame.Poke.Rank>();
            var players = new Player[] { new HumanPlayer(1), new AIPlayer(2), new AIPlayer(3), new AIPlayer(4) };

            //var unoGame = new UnoGame(deck, players);
            //unoGame.Start();


            //IDeck deck = new Deck();
            //var players = new Player[] { new HumanPlayer(1), new AIPlayer(2), new AIPlayer(3), new AIPlayer(4) };

            var showdown = new Showdown(deck, players);
            showdown.Start();

        }
    }
}