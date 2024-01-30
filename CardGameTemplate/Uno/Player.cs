using CardGame.Common;
namespace CardGame.Uno
{
    internal abstract class Player : Player<Card>
    {
        protected Player(int index) : base(index)
        {
        }

        public abstract Card SelectCard(Suit suit);
    }
}
