using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Hand 
    {
        private Player player;
        private List<Card> Cards = new List<Card>();

        public int Size() 
        {
            return Cards.Count;
        }
    }
}
