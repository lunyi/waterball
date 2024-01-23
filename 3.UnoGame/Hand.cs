namespace _3.UnoGame
{
    internal class Hand
    {
        private List<Card> Cards = new List<Card>();
        private Card[] OrderedCards;
        public void AddHandCard(Card card)
        {
            Cards.Add(card);
            OrderedCards = SortCards();
        }

        public int Size() 
        {
            return Cards.Count;
        }

        public Card SelectCard(Suit suit)
        {              
            var card =  OrderedCards.Where(p=>p.Suit == suit).ToList().FirstOrDefault();
            if (card != null)
            {
                Cards.Remove(card);
            }
            OrderedCards = SortCards();
            return card;
        }

        private Card[] SortCards()
        {
            return Cards
                .OrderBy(p => p.Suit)
                .ThenBy(p => p.Rank).ToArray();

        }
        public Card[] ShowCards()
        {
            return OrderedCards.ToArray();
        }
    }
}
