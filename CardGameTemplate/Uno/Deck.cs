using CardGame.Common;

namespace CardGame.Uno
{
    internal class Deck : Deck<Card>
    {
        protected override List<Card> GenerateCards()
        {
            var generatedCards = new List<Card>();

            foreach (var suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)))
                {
                    generatedCards.Add(new Card(suit, rank));
                }
            }
            return generatedCards;
        }
    }
}
