using Game.Uno;

namespace Game
{
    internal interface IUnoOperation
    {
        void AddUnoCard(dynamic unoCard);
        void SetUnoHand(IUnoHand unoHand);
        int GetCardSize();
    }
    internal partial class Player : IUnoOperation
    {
        public IUnoHand UnoHand { get; set; }

        public void SetUnoHand(IUnoHand unoHand)
        {
            UnoHand = unoHand;
        }

        public void AddUnoCard(dynamic unoCard)
        {
            UnoHand.AddUnoCard(unoCard);
        }

        public int GetCardSize()
        {
            return UnoHand.GetCardSize();
        }
    }
}
