namespace CardGame.Base
{
    internal abstract class Deck<Card>
    {
        const int ShuffleIterations = 1000;
        private Stack<Card> _cards;
        static Random random = new Random();

        public Deck()
        {
            Shuffle();
        }

        protected abstract List<Card> GenerateCards();

        public void Shuffle()
        {
            var cards = GenerateCards();
            Shuffle(cards.ToArray());
        }

        public void Shuffle(Card[] cards)
        {
            for (int times = 0; times < ShuffleIterations; times++)
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    int secondCardIndex = random.Next(cards.Length);
                    (cards[i], cards[secondCardIndex]) = (cards[secondCardIndex], cards[i]);
                }
            }
            _cards = new Stack<Card>(cards);
        }

        public Card? DrawCard()
        {
            if (_cards.Count == 0)
            {
                return default;
            }
            return _cards.Pop();
        }

        
        public int Size()
        {
            return _cards.Count;
        }

        public Card[] GetAllCards()
        {
            return _cards.ToArray();
        }
    }
}
