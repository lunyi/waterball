namespace Game.Players
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int index) : base(index) { }

        public override void SelectCard()
        {
            Hand.SelectCard(Hand.Size());
        }

        public override void Naming(string name)
        {
            Console.WriteLine("Please input your name.");
            var inputname = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputname) ? name : inputname;
        }
    }
}
