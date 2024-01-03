using Game.Players;

namespace Game.Card
{
    internal interface IHandCard
    {
        void AddHandCard(Card<Rank,Suit> card);
        int Size();
        Card<Rank, Suit> SelectCard(int index);
        Card<Rank,Suit>[] ShowCards();
        Card<Rank,Suit> ShowCard();
        void SetPlayer(Player player);
        Player GetPlayer();
        void ClearCards();
    }
    internal class HandCard : IHandCard
    {
        private Card<Rank,Suit> CurrentCard { get; set; }
        private IList<Card<Rank, Suit>> Cards = new List<Card<Rank, Suit>>();
        private IList<Card<Rank, Suit>> OrderedCards;

        private Player? Player { get; set; }
        public void AddHandCard(Card<Rank, Suit> card)
        {
            Cards.Add(card);
            OrderedCards = Cards.OrderBy(p => p.Ranks).ThenBy(p => p.Suits).ToList();
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

        public Card<Rank, Suit> ShowCard()
        {
            return CurrentCard;
        }

        public Card<Rank, Suit> SelectCard(int index)
        {
            var card =  OrderedCards[index-1];
            OrderedCards.RemoveAt(index-1);
            CurrentCard = card;
            return card;
        }

        public Card<Rank, Suit>[] ShowCards()
        {  
            return OrderedCards.ToArray();
        }

        public Player GetPlayer()
        {
            return Player;
        }
    }
}
