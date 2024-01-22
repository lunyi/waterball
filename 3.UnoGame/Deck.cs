namespace _3.UnoGame
{
    internal interface IDeck
    {
        void Shuffle();
        void Shuffle(Card[] cards);
        Card? DrawCard();
        int Size();
    }

    internal class Deck : IDeck
    {
        const int Num_Of_Cards = 40;
        const int Num_Of_Ranks = 10;
        const int ShuffleIterations = 1000;
        private List<Card> _cards;
        static Random r = new Random();

        public Deck()
        {
            Shuffle();
        }

        private List<Card> GenerateCards()
        {
            var generatedCards = new List<Card>(Num_Of_Cards);

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    generatedCards.Add(new Card(suit, rank));
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

        public void Shuffle(Card[] cards)
        {
            for (int times = 0; times < ShuffleIterations; times++)
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    int secondCardIndex = r.Next(Num_Of_Ranks);
                    (cards[i], cards[secondCardIndex]) = (cards[secondCardIndex], cards[i]);
                }
            }

            _cards = cards.ToList();
        }

        public Card? DrawCard()
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
    }
}
