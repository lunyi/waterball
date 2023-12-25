using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Deck
    {
        const int Nun_Of_Cards = 52;
        private Card[] cards;

        public Deck()
        {
            cards = new Card[Nun_Of_Cards];
        }

        public Card[] getCards()
        { 
            return cards;
        }

        public void SetUpDeck()
        {
            int count = 0;
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)))
                {
                    cards[count] = new Card((Suit)suit, (Rank)rank);
                    count++;
                }
            }

            Shuffle();
        }
        public void Shuffle() 
        {
            Random r = new Random();
            Card temp;

            for (int times = 0; times < 1000; times++) 
            {
                for (int i = 0; i < Nun_Of_Cards; i++)
                {
                    int secondCardIndex = r.Next(13);
                    temp = cards[i];
                    cards[i] = cards[secondCardIndex];
                    cards[secondCardIndex] = temp;
                }
            }
        }
        //public Card DrawCard() 
        //{
        //    return new Card();
        //}
    }
}
