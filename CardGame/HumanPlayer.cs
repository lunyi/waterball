namespace CardGame
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int index) : base(index) { }

        public override void TakeTurns()
        {
            _hand.PickupCard(_hand.Size());
        }

        public override void NameHimself(string name)
        {
            Console.WriteLine("Please input your name.");
            var inputname = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputname) ? name : inputname; 
        }
    }
}
