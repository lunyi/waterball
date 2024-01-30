using CardGame.Common;
using CardGame.Uno;
using System.Text;
using UnoHumanPlayer = CardGame.Uno.HumanPlayer;
using UnoAIPlayer = CardGame.Uno.AIPlayer;
using ShowdownDeck = CardGame.Showdown.Deck;
using ShowdownHumanPlayer = CardGame.Showdown.HumanPlayer;
using ShowdownAIPlayer = CardGame.Showdown.AIPlayer;
using Card = CardGame.Showdown.Card;
using UnoCard = CardGame.Uno.Card;
using UnoDeck = CardGame.Uno.Deck;
using CardGame.Showdown;

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
            StartShowdown();
        }

        private static void StartShowdown()
        {
            var deck = new ShowdownDeck();
            var players = new Player<Card>[] { new ShowdownHumanPlayer(1), new ShowdownAIPlayer(2), new ShowdownAIPlayer(3), new ShowdownAIPlayer(4) };
            var showdown = new Showdown(deck, players);
            showdown.Start();
        }

        private static void StartUno()
        {
            var deck = new UnoDeck();
            var players = new Player<UnoCard>[] { new UnoHumanPlayer(1), new UnoAIPlayer(2), new UnoAIPlayer(3), new UnoAIPlayer(4) };
            var unoGame = new UnoGame(deck, players);
            unoGame.Start();
        }
    }
}