namespace CardGame
{
    internal class AIPlayer : Player
    {
        private static Random _random = new Random();
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override Card SelectCard()
        {
            if (ExchangeHands == null)
            {
                var ifexhange = random.Next(0, 3);
                if (ifexhange == 0)
                {
                    var exchangees = Showdown.GetPlayers()
                        .Where(p => p.Index != Index)
                        .ToArray();

                    ExchangeHands = new ExchangeHands(this, exchangees[random.Next(0, exchangees.Count())]);
                }
            }
            else
            {
                ExchangeHands.CountDown();
            }

            return Hand.SelectCard(Hand.Size());
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }
    }
}
