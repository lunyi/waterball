namespace CardGame
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer() : base() { }

        public override void NameHimself(string name)
        {
            Name = name;
        }

        public override bool makeExchangeHandsDecision()
        {
            var res = Console.ReadLine();
            return res == "Y" || res == "y" ;
        }
    }
}
