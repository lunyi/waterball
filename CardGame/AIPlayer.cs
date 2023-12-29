namespace CardGame
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) { }

        public override void TakeTurns()
        {
            Hand.PickupCard(r.Next(1, Hand.Size()));
        }

        public override void NameHimself(string name) 
        { 
            Name = name;
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
                        ExchangeHands.ExchangeHand(this, players[_index]);
                    }
                }
            }
        }
    }
}
