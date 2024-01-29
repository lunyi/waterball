namespace CardGame.Common
{
    internal class Hand<TSuit, TRank>
        where TSuit : Enum
        where TRank : Enum
    {
        private List<Card<TSuit, TRank>> Cards = new List<Card<TSuit, TRank>>();
        public void AddHandCard(Card<TSuit, TRank> card)
        {
            Cards.Add(card);
        }

        public int Size() 
        {
            return Cards.Count;
        }

        public Card<TSuit, TRank> SelectCard(dynamic suit)
        {              
            var card = Cards.Where(p=>p.Suit == suit).FirstOrDefault();
            if (card != null)
            {
                Cards.Remove(card);
            }
            Cards = SortCards();
            return card;
        }

        public Card<TSuit, TRank> SelectCard(int index)
        {
            if (index == 0)
            {
                return null;
            }
            Cards = SortCards();
            var indexToDelete = index - 1;
            var card = Cards[indexToDelete];
            Cards.RemoveAt(indexToDelete);
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
            return Cards.ToArray();
        }
    }
}
