using CardGame.Base;

namespace CardGame.Showdown
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int index) : base(index) { }
        public override void Naming()
        {
            Console.WriteLine("Please input your name.");
            var inputname = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputname) ? "human" : inputname;
            Name = $"{Name}-{Index}";
        }

        public override Card SelectCard()
        {
            var cards = Hand.ShowCards()
                .OrderByDescending(p=>p.Rank)
                .ThenByDescending(c=>c.Suit);
            var card = cards.First();
            Hand.Remove(card);
            return card;
        }
    }
}
