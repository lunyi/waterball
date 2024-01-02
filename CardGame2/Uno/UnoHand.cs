namespace Game.Uno
{
    internal interface IUnoHand
    {
        void AddUnoCard(Card<RankUno, SuitUno> card);
        Card<RankUno, SuitUno>[] GetCards();
        Card<RankUno, SuitUno> GetCurrentCard();
        Card<RankUno, SuitUno>[] FindCardsBySuit(SuitUno suit);

        int GetCardSize();
    }
    internal class UnoHand : IUnoHand
    {
        public List<Card<RankUno, SuitUno>> Cards ;
        public Card<RankUno, SuitUno> CurrentCard;

        public UnoHand()
        {
            Cards = new List<Card<RankUno, SuitUno>>();
            CurrentCard = null;
        }
        public void AddUnoCard(Card<RankUno, SuitUno> card)
        {
            Cards.Add(card);
        }

        public Card<RankUno, SuitUno>[] FindCardsBySuit(SuitUno suit)
        {
            return Cards.Where(p=>p.Suits.Equals(suit)).ToArray();
        }

        public Card<RankUno, SuitUno>[] GetCards()
        {
            return Cards.ToArray();
        }

        public Card<RankUno, SuitUno> GetCurrentCard()
        {
            return CurrentCard;
        }

        public void AddHandCard(Card<RankUno,SuitUno> card)
        {
            Cards.Add(card);
        }

        public int GetCardSize()
        {
            return Cards.Count;
        }
    }
}
