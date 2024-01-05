namespace CardGame
{
    internal class Hand
    {
        private Card CurrentCard { get; set; }
        private List<Card> Cards = new List<Card>();
        private List<Card> OrderedCards;
        internal Player? Player { get; set; }
        public void AddHandCard(Card card)
        {
            Cards.Add(card);
            OrderedCards = Cards.SortCards();
        }

        public int Size() 
        {
            return OrderedCards.Count;
        }

        public void ClearCards()
        {
            Cards.Clear();
        }

        public Card ShowCard()
        {
            return CurrentCard;
        }

        public Card SelectCard(int index)
        {
            var card =  OrderedCards[index-1];
            OrderedCards.RemoveAt(index-1);
            CurrentCard = card;
            return card;
        }

        public void RemoveCard(Card card)
        {
            var cardToRemove = Cards.FirstOrDefault(p => p.Rank == card.Rank && p.Suit == card.Suit);
            Cards.Remove(cardToRemove);
            OrderedCards = Cards.SortCards();
        }

        public List<Card> ShowCards()
        {  
            return OrderedCards.ToList();
        }
    }
}
