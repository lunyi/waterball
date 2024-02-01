namespace CardGame
{
    internal interface IDeck
    {
        void Shuffle();
        Card? DrawCard();
    }
    internal class Deck : IDeck
    {
        const int ShuffleIterations = 1000;
        private Stack<Card> _cards;
        static Random r = new Random();

        public Deck()
        {
            Shuffle();
        }

        private List<Card> GenerateCards()
        {
            var generatedCards = new List<Card>();

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
            var cards = GenerateCards();
            for (int times = 0; times < ShuffleIterations; times++) 
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    int secondCardIndex = r.Next(cards.Count);
                    (cards[i], cards[secondCardIndex]) = (cards[secondCardIndex], cards[i]);
                }
            }
            _cards = new Stack<Card>(cards);
        }
        public Card? DrawCard() 
        {
            if (_cards.Count == 0)
            {
                return null;
            }

            return _cards.Pop();
        }
    }
}
