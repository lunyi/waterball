using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CardGame
{
    internal abstract class Player 
    {
        private int Point ;
        private string Name ;

        private List<Hand> hands = new List<Hand>();

        public abstract void NameHimself(string name);
        public abstract void makeExchangeHandsDecision();
        public abstract Card ShowCard();

        public void AddHandCard(Card card)
        {
            
        }

        public void TakeTurn()
        { 
        
        }

        public void GainPoint()
        { 

        }

        public void ExchangeHands(Player exchangee)
        { 

        }
    }
}
