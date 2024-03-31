namespace CardGame.Base
{
    internal abstract class Deck<TCard> where TCard : class
    {
        private const int ShuffleIterations = 1000;
        private Stack<TCard> _cards;
        private static Random random = new Random();

        public Deck()
        {
            var cards = GenerateCards();
            Shuffle();
        }
        protected abstract List<TCard> GenerateCards();

        public void Shuffle()
        {
            var cards = GenerateCards();
            Shuffle(cards);
        }

        public void Shuffle(List<TCard> cards)
        {
            for (int n = cards.Count - 1; n > 0; --n)
            {
                int k = random.Next(n + 1);
                (cards[n], cards[k]) = (cards[k], cards[n]);
            }
        }
        public TCard DrawCard()
        {
            return _cards.Count == 0 ? null : _cards.Pop();
        }

        public int Size() => _cards.Count;

        //public Card[] GetAllCards()
        //{
        //    return _cards.ToArray();
        //}
    }
}
