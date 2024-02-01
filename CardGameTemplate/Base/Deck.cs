namespace CardGame.Base
{
    internal abstract class Deck<Card>
    {
        const int ShuffleIterations = 1000;
        private List<Card> _cards;
        static Random r = new Random();

        public Deck()
        {
            Shuffle();
        }

        protected abstract List<Card> GenerateCards();

        public void Shuffle()
        {
            _cards = GenerateCards();
            Shuffle(_cards.ToArray());
        }

        public void Shuffle(Card[] cards)
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

        public Card? DrawCard()
        {
            if (_cards.Count == 0)
            {
                return default;
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

        public Card[] GetAllCards()
        {
            return _cards.ToArray();
        }
    }
}
