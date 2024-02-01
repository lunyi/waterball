using CardGame.Common;
using CardGame.Uno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Showdown
{
    internal class Deck : Deck<Card>
    {
        protected override List<Card> GenerateCards()
        {
            var generatedCards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    generatedCards.Add(new Card(suit, rank));
                }
            }
            return generatedCards;
        }
    }
}
