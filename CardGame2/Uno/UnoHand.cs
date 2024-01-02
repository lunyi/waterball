namespace Game.Uno
{
    internal interface IUnoHand
    {
        Card<RankUno, SuitUno>[] GetCards();
        Card<RankUno, SuitUno> GetCurrentCard();
        Card<RankUno, SuitUno>[] FindCardsBySuit(SuitUno suit);

        int Size();
    }
    internal class UnoHand : IUnoHand
    {
        public List<Card<RankUno, SuitUno>> Cards;
        public Card<RankUno, SuitUno> CurrentCard;

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

        public int Size()
        {
            return Cards.Count;
        }
    }
}
