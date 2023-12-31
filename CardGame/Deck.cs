namespace CardGame
{
    internal interface IDeck
    {
        void Shuffle();
        Card DrawCard();

    }
    internal class Deck : IDeck
    {
        const int Num_Of_Cards = 52;
        const int Num_Of_Ranks = 13;
        const int ShuffleIterations = 1000;
        private List<Card> cards;
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
            cards = GenerateCards();
            for (int times = 0; times < ShuffleIterations; times++) 
            {
                for (int i = 0; i < Num_Of_Cards; i++)
                {
                    int secondCardIndex = r.Next(Num_Of_Ranks);
                    (cards[i], cards[secondCardIndex]) = (cards[secondCardIndex], cards[i]);
                }
            }
        }
        public Card? DrawCard() 
        {
            if (cards.Count == 0)
            {
                return null;
            }

            var index = r.Next(0, cards.Count - 1);
            var card = cards[index] ;
            cards.RemoveAt(index);
            return card;
        }
    }
}
