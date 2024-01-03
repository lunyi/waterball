namespace Game.Uno
{
    internal interface IUnoHand
    {
        void AddUnoCard(Card<RankUno, SuitUno> card);
        Card<RankUno, SuitUno>[] GetCards();
        Card<RankUno, SuitUno>? GetCardBySuit(SuitUno suit);

        int GetCardSize();
    }
    internal class UnoHand : IUnoHand
    {
        public List<Card<RankUno, SuitUno>> Cards ;

        public UnoHand()
        {
            Cards = new List<Card<RankUno, SuitUno>>();
        }
        public void AddUnoCard(Card<RankUno, SuitUno> card)
        {
            Cards.Add(card);
        }

        public Card<RankUno, SuitUno>? GetCardBySuit(SuitUno suit)
        {
            var cards = Cards.Where(p => p.Suits.Equals(suit)).ToArray();
            if (cards.Length == 0)
            {
                return null;
            }
            else 
            { 
                return cards[0];
            }
        }

        public Card<RankUno, SuitUno>[] GetCards()
        {
            return Cards.ToArray();
        }

        public int GetCardSize()
        {
            return Cards.Count;
        }
    }
}
