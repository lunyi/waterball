namespace CardGame
{
    internal class Deck
    {
        const int Nun_Of_Cards = 52;
        private List<Card> cards;
        static Random r = new Random();

        public Deck()
        {
            cards = new List<Card>(Nun_Of_Cards);
            int count = 0;
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card((Suit)suit, (Rank)rank));
                    count++;
                }
            }

            Shuffle();
        }

        public void Shuffle() 
        {
            Card temp;

            for (int times = 0; times < 1000; times++) 
            {
                for (int i = 0; i < Nun_Of_Cards; i++)
                {
                    int secondCardIndex = r.Next(13);
                    temp = cards[i];
                    cards[i] = cards[secondCardIndex];
                    cards[secondCardIndex] = temp;
                }
            }
        }
        public Card DrawCard() 
        {
            if (cards.Count == 0)
                return null;

            var index = r.Next(0, cards.Count - 1);
            var card = cards[index] ;
            cards.RemoveAt(index);
            return card;
        }
    }
}
