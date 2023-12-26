namespace CardGame
{
    internal class Hand 
    {
        private List<Card> Cards = new List<Card>();
        private List<Card> OrderedCards;

        public void AddHand(Card card)
        {
            Cards.Add(card);
        }
        public int Size() 
        {
            return Cards.Count;
        }

        public Card PickupCard(int index)
        {
            var card =  OrderedCards[index];
            OrderedCards.RemoveAt(index);
            return card;
        }

        public Card[] ShowCards()
        {
            OrderedCards = Cards.OrderBy(p => p.Ranks).ThenBy(p => p.Suits).ToList();
            return OrderedCards.ToArray();
        }
    }
}
