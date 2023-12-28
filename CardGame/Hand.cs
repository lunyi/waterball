namespace CardGame
{
    internal class Hand 
    {
        public Card CurrentCard { get; set; }
        private List<Card> Cards = new List<Card>();
        private List<Card> OrderedCards;

        public Player Player { get; set; }
        public void AddHand(Card card)
        {
            Cards.Add(card);
            OrderedCards = Cards.OrderBy(p => p.Ranks).ThenBy(p => p.Suits).ToList();
        }
        public int Size() 
        {
            return OrderedCards.Count;
        }

        public Card PickupCard(int index)
        {
            var card =  OrderedCards[index-1];
            OrderedCards.RemoveAt(index-1);
            CurrentCard = card;
            return card;
        }

        public Card[] ShowCards()
        {  
            return OrderedCards.ToArray();
        }
    }
}
