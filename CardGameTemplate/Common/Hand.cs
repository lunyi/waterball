namespace CardGame.Common
{
    internal class Hand<Card> : List<Card>
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

        public void Remove(Card card)
        {
            Cards.Remove(card);
        }

        public Card[] ShowCards()
        {
            return Cards.ToArray();
        }
    }
}
