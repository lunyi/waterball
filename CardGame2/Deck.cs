
namespace Game
{
    internal interface IDeck<T, TRank, TSuit> 
        where T:class 
        where TRank : Enum 
        where TSuit : Enum
    {
        void Shuffle();
        T? DrawCard();
        T[] Shuffle(T[] cards);

    }
    internal class Deck<T, TRank, TSuit> : IDeck<T, TRank, TSuit>
        where T : class
        where TRank : Enum
        where TSuit : Enum
    {
        int Num_Of_Cards = Enum.GetValues(typeof(TRank)).Length * Enum.GetValues(typeof(TSuit)).Length;
        int Num_Of_Ranks = Enum.GetValues(typeof(TRank)).Length;
        const int ShuffleIterations = 1000;
        private List<T> _cards;
        static Random r = new Random();

        public Deck()
        {
            Shuffle();
        }


        private List<T> GenerateCards()
        {
            var generatedCards = new List<T>(Num_Of_Cards);

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    generatedCards.Add((T)Activator.CreateInstance(typeof(T), suit, rank));
                }
            }
            return generatedCards;
        }

        public void Shuffle()
        {
            _cards = GenerateCards();
            for (int times = 0; times < ShuffleIterations; times++)
            {
                for (int i = 0; i < Num_Of_Cards; i++)
                {
                    int secondCardIndex = r.Next(Num_Of_Ranks);
                    (_cards[i], _cards[secondCardIndex]) = (_cards[secondCardIndex], _cards[i]);
                }
            }
        }

        public T[] Shuffle(T[] cards)
        {
            for (int times = 0; times < ShuffleIterations; times++)
            {
                for (int i = 0; i < Num_Of_Cards; i++)
                {
                    int secondCardIndex = r.Next(Num_Of_Ranks);
                    (cards[i], cards[secondCardIndex]) = (cards[secondCardIndex], cards[i]);
                }
            }
            return cards;
        }

        public T? DrawCard() 
        {
            if (_cards.Count == 0)
            {
                return null;
            }

            var index = r.Next(0, _cards.Count - 1);
            var card = _cards[index] ;
            _cards.RemoveAt(index);
            return card;
        }
    }
}
