using CardGame.Common;
namespace CardGame.Uno
{
    internal abstract class Player : Player<Card>
    {
        protected Player(int index) : base(index)
        {
        }

        public Card SelectCard(Card targetTard)
        {
            var cards = Hand.ShowCards();
            var filterCards = cards.Where(p => p.Suit == targetTard.Suit).ToList();
            var card = filterCards.First();
            Hand.Remove(card);
            return card;
        }
    }
}
