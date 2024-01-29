namespace CardGame
{
    internal class Hand
    {
        private List<Card> Cards = new List<Card>();
        public void AddHandCard(Card card)
        {
            Cards.Add(card);
        }

        public int Size() 
        {
            return Cards.Count;
        }

        public Card SelectCard(int index)
        {
            if (index == 0) 
            {
                return null;
            }
                
            var card = Cards[index-1];
            Cards.RemoveAt(index-1);
            return card;
        }

        public Card[] ShowCards()
        {  
            return Cards.ToArray();
        }
    }
}
