using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Card
    {


        public Suit Suits { get; set; }
        public Rank Ranks { get; set; }

        public Card(Suit suit, Rank rank)
        { 
            Ranks = rank;
            Suits = suit;
        }
    }

    internal enum Suit
    {
        club = 0,
        Diamond = 1,
        Heart = 2,
        Spade = 3
    }

    internal enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        Ling = 13,
        Ace = 14
    }
}
