namespace CardGame.Common
{
    internal class Hand<TSuit, TRank>
        where TSuit : Enum
        where TRank : Enum
    {
        private List<Card<TSuit, TRank>> Cards = new List<Card<TSuit, TRank>>();
        private List<Card<TSuit, TRank>> OrderedCards;
        public void AddHandCard(Card<TSuit, TRank> card)
        {
            Cards.Add(card);
            OrderedCards = SortCards();
        }

        public int Size() 
        {
            return Cards.Count;
        }

        public Card<TSuit, TRank> SelectCard(dynamic suit)
        {              
            var card =  OrderedCards.Where(p=>p.Suit == suit).FirstOrDefault();
            if (card != null)
            {
                Cards.Remove(card);
            }
            OrderedCards = SortCards();
            return card;
        }

        public Card<TSuit, TRank> SelectCard(int index)
        {
            if (index == 0)
            {
                return null;
            }

            var card = OrderedCards[index - 1];
            OrderedCards.RemoveAt(index - 1);
            return card;
        }

        private List<Card<TSuit, TRank>> SortCards()
        {
            return Cards
                .OrderBy(p => p.Suit)
                .ThenBy(p => p.Rank).ToList();

        }
        public Card<TSuit, TRank>[] ShowCards()
        {
            return OrderedCards.ToArray();
        }
    }
}
