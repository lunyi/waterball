namespace CardGame.Common
{
    internal class Hand<Card>
    {
        private List<Card> Cards = new List<Card>();
        public void AddHandCard(Card card)
        {
            Cards.Add(card);
        }

        public int Size() 
        {
            return Cards.Count;
        }

        public Card SelectCard(dynamic suit)
        {              
            var card = Cards.Where(p=>p.Suit == suit).FirstOrDefault();
            if (card != null)
            {
                Cards.Remove(card);
            }
            Cards = SortCards();
            return card;
        }

        public Card SelectCard(int index)
        {
            if (index == 0)
            {
                return default;
            }
            Cards = SortCards();
            var indexToDelete = index - 1;
            var card = Cards[indexToDelete];
            Cards.RemoveAt(indexToDelete);
            return card;
        }

        private List<Card> SortCards()
        {
            return Cards
                .OrderBy(p => p.Suit)
                .ThenBy(p => p.Rank).ToList();

        }
        public Card[] ShowCards()
        {
            return Cards.ToArray();
        }
    }
}
