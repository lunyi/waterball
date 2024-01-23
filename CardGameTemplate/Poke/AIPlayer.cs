using CardGame.Common;

namespace CardGame.Poke
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override Card<Suit, Rank> SelectCard()
        {
            if (ExchangeHands == null)
            {
                var ifexhange = random.Next(0, 3);
                if (ifexhange == 0)
                {
                    var exchangees = Showdown.GetPlayers()
                        .Where(p => p.ExchangeHands == null && p.Index != Index)
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
