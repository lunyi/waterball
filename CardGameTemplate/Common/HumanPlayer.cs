using CardGame.Common;
using System.Numerics;

namespace CardGame.Common
{
    internal class HumanPlayer<TSuit, TRank> : Player<TSuit, TRank>
        where TSuit : Enum
        where TRank : Enum
    {
        public HumanPlayer(int index) : base(index) { }

        public override Card<TSuit, TRank> SelectCard(TSuit suit)
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
