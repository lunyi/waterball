using CardGame.Common;

namespace CardGame.Uno
{
    internal class Hand
    {
        private List<Card<Suit, Rank>> Cards = new List<Card<Suit, Rank>>();
        private Card<Suit, Rank>[] OrderedCards;
        public void AddHandCard(Card<Suit, Rank> card)
        {
            Cards.Add(card);
            OrderedCards = SortCards();
        }

        public int Size() 
        {
            return Cards.Count;
        }

        public Card<Suit, Rank> SelectCard(Suit suit)
        {              
            var card =  OrderedCards.Where(p=>p.Suit == suit).ToList().FirstOrDefault();
            if (card != null)
            {
                Cards.Remove(card);
            }
            OrderedCards = SortCards();
            return card;
        }

        private Card<Suit, Rank>[] SortCards()
        {
            return Cards
                .OrderBy(p => p.Suit)
                .ThenBy(p => p.Rank).ToArray();

        }
        public Card<Suit, Rank>[] ShowCards()
        {
            return OrderedCards.ToArray();
        }
    }
}
