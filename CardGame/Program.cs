using System.Text;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitConsoleSetting();
            IDeck deck = new Deck();
            var players = new Player[] { new HumanPlayer(1), new AIPlayer(2), new AIPlayer(3), new AIPlayer(4) };

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