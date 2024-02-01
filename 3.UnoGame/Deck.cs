using System.Runtime.CompilerServices;

namespace _3.UnoGame
{
    internal interface IDeck
    {
        void Shuffle();
        void Shuffle(Card[] cards);
        Card? DrawCard();
        int Size();
        Card[] GetAllCards();
    }

    internal class Deck : IDeck
    {
        const int Num_Of_Cards = 40;
        const int ShuffleIterations = 1000;
        private Stack<Card> _cards;
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
            var cards = GenerateCards();
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
