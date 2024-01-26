using CardGame.Common;
using CardGame.Poke;
using CardGame.Uno;
using System.Text;
using PokeHumanPlayer = CardGame.Poke.HumanPlayer;
using PokeAIPlayer = CardGame.Poke.AIPlayer;
using UnoHumanPlayer = CardGame.Uno.HumanPlayer;
using UnoAIPlayer = CardGame.Uno.AIPlayer;
using PokeSuit = CardGame.Poke.Suit;
using PokeRank = CardGame.Poke.Rank;
using UnoSuit = CardGame.Uno.Suit;
using UnoRank = CardGame.Uno.Rank;

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
            var deck = new Deck<PokeSuit, PokeRank>();
            var players = new Player<PokeSuit, PokeRank>[] { new PokeHumanPlayer(1), new PokeAIPlayer(2), new PokeAIPlayer(3), new PokeAIPlayer(4) };
            var showdown = new Showdown(deck, players);
            showdown.Start();
        }

        private static void StartUno()
        {
            var deck = new Deck<UnoSuit, UnoRank>();
            var players = new Player<UnoSuit, UnoRank>[] { new UnoHumanPlayer(1), new UnoAIPlayer(2), new UnoAIPlayer(3), new UnoAIPlayer(4) };
            var unoGame = new UnoGame(deck, players);
            unoGame.Start();
        }
    }
}