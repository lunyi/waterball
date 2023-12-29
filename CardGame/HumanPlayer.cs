namespace CardGame
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int index) : base(index) { }

        public override void TakeTurns()
        {
            Hand.PickupCard(Hand.Size());
        }

        public override void NameHimself(string name)
        {
            Console.WriteLine("Please input your name.");
            var inputname = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputname) ? name : inputname; 
        }

        public override void makeExchangeHandsDecision(IList<Player> players)
        {
            if (ExchangeHands.GetCountDown() == 3)
            {
                Console.WriteLine($"Hi {Name}, do you want to change hand?");
                string userInput = Console.ReadLine()?.ToLower();
                if (userInput == "y")
                {
                    Console.WriteLine($"Hi {Name}, which player do you choose to exchange?");
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != _index)
                    {
                        ExchangeHands.ExchangeHand(this, players.FirstOrDefault(p => p._index == playerIndex));
                    }
                }
            }
        }
    }
}
