using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class HumanPlayer : Player
    {
        private string? _name;
        private List<Hand> hands = new List<Hand>();

        public override void NameHimself(string name) 
        { 
            _name = name;
        }

        public override void makeExchangeHandsDecision()
        {
            throw new NotImplementedException();
        }

        public override Card ShowCard()
        {
            throw new NotImplementedException();
        }
    }
}
