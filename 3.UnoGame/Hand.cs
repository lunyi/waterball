namespace _3.UnoGame
{
    internal class Hand
    {
        private IList<Card> Cards = new List<Card>();
        private IList<Card> OrderedCards;
        public void AddHandCard(Card card)
        {
            Cards.Add(card);
            OrderedCards = Cards
                .OrderBy(p => p.Suit)
                .ThenBy(p => p.Rank).ToList();
        }

        public int Size() 
        {
            return OrderedCards.Count;
        }

        public Card SelectCard(Suit suit)
        {              
            var card =  OrderedCards.Where(p=>p.Suit == suit).ToList().FirstOrDefault();
            if (card != null)
            {
                Cards.Remove(card);
            }
            return card;
        }

        public Card[] ShowCards()
        {  
            return OrderedCards.ToArray();
        }
    }
}
