using System.Runtime.InteropServices;

namespace CardGame
{
    internal class AIPlayer : Player
    {
        public AIPlayer() : base() { }

        public override void NameHimself(string name) 
        { 
            Name = name;
        }

        public override bool makeExchangeHandsDecision()
        {
            if (exchangeHand == false)
            { 
                var result = new Random().Next(0, 3);
                if (result == 0) 
                {
                    exchangeHand = true;
                    return true;
                }
            }
            return false;
        }
    }
}
