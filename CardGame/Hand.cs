using System.Security.Cryptography;

namespace CardGame
{
    internal interface IHand
    {
        void AddHandCard(Card card);
        int Size();
        Card SelectCard(int index);
        Card[] ShowCards();
        Card ShowCard();
        void SetPlayer(Player player);
        Player GetPlayer();
        void ClearCards();

    }
    internal class Hand : IHand
    {
        private Card CurrentCard { get; set; }
        private IList<Card> Cards = new List<Card>();
        private IList<Card> OrderedCards;

        private Player? Player { get; set; }
        public void AddHandCard(Card card)
        {
            Cards.Add(card);
            OrderedCards = Cards.OrderBy(p => p.Rank).ThenBy(p => p.Suit).ToList();
        }

        public int Size() 
        {
            return OrderedCards.Count;
        }

        public void ClearCards()
        {
            Cards.Clear();
        }

        public void SetPlayer(Player player)
        {
            Player = player;
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

        public Card[] ShowCards()
        {  
            return OrderedCards.ToArray();
        }

        public Player GetPlayer()
        {
            return Player;
        }
    }
}
