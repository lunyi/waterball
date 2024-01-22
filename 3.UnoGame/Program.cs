using System.Text;

namespace _3.UnoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitConsoleSetting();
            IDeck deck = new Deck();
            var players = new Player[] { new HumanPlayer(1), new AIPlayer(2), new AIPlayer(3), new AIPlayer(4) };

            var unoGame = new UnoGame(deck, players);
            unoGame.Start();
        }

        private static void InitConsoleSetting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(130, 600);
        }
    }
}