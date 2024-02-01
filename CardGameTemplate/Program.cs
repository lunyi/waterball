using CardGame.Base;
using CardGame.Showdown;
using CardGame.Uno;
using System.Text;
using ShowdownAIPlayer = CardGame.Showdown.AIPlayer;
using ShowdownDeck = CardGame.Showdown.Deck;
using ShowdownHumanPlayer = CardGame.Showdown.HumanPlayer;
using ShowdownPlayer = CardGame.Showdown.Player;
using UnoAIPlayer = CardGame.Uno.AIPlayer;
using UnoDeck = CardGame.Uno.Deck;
using UnoHumanPlayer = CardGame.Uno.HumanPlayer;
using UnoPlayer = CardGame.Uno.Player;

namespace Game
{
    internal class Program
    {
        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(130, 600);
            Console.OutputEncoding = Encoding.UTF8;
        }

        static void Main(string[] args)
        {
            InitConsoleSetting();
            StartUno();
        }

        private static void StartShowdown()
        {
            var deck = new ShowdownDeck();
            var players = new ShowdownPlayer[] { new ShowdownHumanPlayer(1), new ShowdownAIPlayer(2), new ShowdownAIPlayer(3), new ShowdownAIPlayer(4) };
            var showdown = new Showdown(deck, players);
            showdown.Start();
        }

        private static void StartUno()
        {
            var deck = new UnoDeck();
            var players = new UnoPlayer[] { new UnoHumanPlayer(1), new UnoAIPlayer(2), new UnoAIPlayer(3), new UnoAIPlayer(4) };
            var unoGame = new UnoGame(deck, players);
            unoGame.Start();
        }
    }
}