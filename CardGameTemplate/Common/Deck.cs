namespace CardGame.Common
{
    internal interface IDeck<TSuit, TRank> 
        where TRank: Enum 
        where TSuit: Enum
    {
        void Shuffle();
        void Shuffle(Card<TSuit, TRank>[] cards);
        Card<TSuit, TRank>? DrawCard();
        int Size();
        Card<TSuit, TRank>[] GetAllCards();
    }

    internal class Deck<TSuit, TRank> : IDeck<TSuit, TRank>
         where TRank : Enum
         where TSuit : Enum
    {
        const int ShuffleIterations = 1000;
        private List<Card<TSuit, TRank>> _cards;
        static Random r = new Random();

        public Deck()
        {
            Shuffle();
        }

        private List<Card<TSuit, TRank>> GenerateCards()
        {
            var generatedCards = new List<Card<TSuit, TRank>>();

            foreach (var suit in Enum.GetValues(typeof(TSuit)))
            {
                foreach (var rank in Enum.GetValues(typeof(TRank)))
                {
                    generatedCards.Add(new Card<TSuit, TRank>((TSuit)suit, (TRank)rank));
                }
            }
            return generatedCards;
        }

        public void Shuffle()
        {
            _cards = GenerateCards();
            Shuffle(_cards.ToArray());
        }

        public void Shuffle(Card<TSuit, TRank>[] cards)
        {
            for (int times = 0; times < ShuffleIterations; times++)
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    int secondCardIndex = r.Next(cards.Length);
                    (cards[i], cards[secondCardIndex]) = (cards[secondCardIndex], cards[i]);
                }
            }
            _cards = cards.ToList();
        }

        public Card<TSuit, TRank>? DrawCard()
        {
            if (_cards.Count == 0)
            {
                return null;
            }

            var index = r.Next(0, _cards.Count - 1);
            var card = _cards[index];
            _cards.RemoveAt(index);
            return card;
        }

        
        public int Size()
        {
            return _cards.Count;
        }

        public Card<TSuit, TRank>[] GetAllCards()
        {
            return _cards.ToArray();
        }
    }
}
