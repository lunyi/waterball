using CardGame.Common;
using CardGame.Poke;

namespace CardGame.Poke
{
    internal class HumanPlayer : Player<Suit, Rank>
    {
        private ExchangeHands? ExchangeHands = null;
        public HumanPlayer(int index) : base(index) { }

        public override void Naming()
        {
            Console.WriteLine("Please input your name.");
            var inputname = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputname) ? "human" : inputname;
            Name = $"{Name}-{Index}";
        }

        public override Card<Suit, Rank> SelectCard()
        {
            if (ExchangeHands == null)
            {
                Console.WriteLine($"Hi {Name}, which player do you choose to exchange hand?");
                try
                {
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != Index && playerIndex >= 1 && playerIndex <= 4)
                    {
                        var exchangee = Game.GetPlayers().FirstOrDefault(p => p.Index == playerIndex);
                        ExchangeHands = new ExchangeHands(this, exchangee);
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid parameter");
                }
            }
            else
            {
                ExchangeHands.CountDown();
            }

            return Hand.SelectCard(Hand.Size());
        }

        public override Card<Suit, Rank> SelectCard(Suit suit)
        {
            return Hand.SelectCard(suit);
        }
    }
}
