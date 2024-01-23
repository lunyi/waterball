using CardGame.Common;

namespace CardGame.Poke
{
    internal class Hand
    {
        private IList<Card<Suit, Rank>> Cards = new List<Card<Suit, Rank>>();
        private IList<Card<Suit, Rank>> OrderedCards;
        public void AddHandCard(Card<Suit, Rank> card)
        {
            Cards.Add(card);
            OrderedCards = Cards.OrderBy(p => p.Rank).ThenBy(p => p.Suit).ToList();
        }

        public int Size() 
        {
            return OrderedCards.Count;
        }

        public Card<Suit, Rank> SelectCard(int index)
        {
            if (index == 0) 
            {
                return null;
            }
                
            var card =  OrderedCards[index-1];
            OrderedCards.RemoveAt(index-1);
            return card;
        }

        public Card<Suit, Rank>[] ShowCards()
        {  
            return OrderedCards.ToArray();
        }
    }
}
