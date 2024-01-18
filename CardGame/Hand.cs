namespace CardGame
{
    internal class Hand
    {
        private IList<Card> Cards = new List<Card>();
        private IList<Card> OrderedCards;
        public void AddHandCard(Card card)
        {
            Cards.Add(card);
            OrderedCards = Cards.OrderBy(p => p.Rank).ThenBy(p => p.Suit).ToList();
        }

        public int Size() 
        {
            return OrderedCards.Count;
        }

        public Card SelectCard(int index)
        {
            if (index == 0) 
            {
                return null;
            }
                
            var card =  OrderedCards[index-1];
            OrderedCards.RemoveAt(index-1);
            return card;
        }

        public Card[] ShowCards()
        {  
            return OrderedCards.ToArray();
        }
    }
}
