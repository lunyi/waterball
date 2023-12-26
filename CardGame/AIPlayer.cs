using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class AIPlayer : Player
    {
        private List<Hand> hands = new List<Hand>();

        public override void NameHimself(string name) 
        { 
            Name = name;
        }

        public override void makeExchangeHandsDecision()
        { 

        }
    }
}
