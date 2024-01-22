using System.Numerics;

namespace _3.UnoGame
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int index) : base(index) { }

        public override Card SelectCard(Suit suit)
        {
            return Hand.SelectCard(suit);
        }

        public override void Naming()
        {
            Console.WriteLine("Please input your name.");
            var inputname = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputname) ? "human" : inputname;
            Name = $"{Name}-{Index}";
        }
    }
}
