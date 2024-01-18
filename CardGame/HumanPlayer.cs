using System.Numerics;

namespace CardGame
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int index) : base(index) { }

        public override Card SelectCard()
        {
            if (ExchangeHands == null)
            {
                Console.WriteLine($" , Hi {Name}, which player do you choose to exchange hand?");
                try
                {
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != Index && playerIndex >= 1 && playerIndex <= 4)
                    {
                        var exchangee = Showdown.GetPlayers().FirstOrDefault(p => p.Index == playerIndex);
                        ExchangeHands = new ExchangeHands(this, exchangee);
                    }
                }
                catch
                {

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
            Console.WriteLine("Please input your name.");
            var inputname = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputname) ? "human" : inputname;
            Name = $"{Name}-{Index}";
        }
    }
}
