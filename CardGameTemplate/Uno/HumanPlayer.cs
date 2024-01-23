using CardGame.Common;
using System.Numerics;

namespace CardGame.Uno
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int index) : base(index) { }

        public override Card<Suit, Rank> SelectCard(Suit suit)
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
