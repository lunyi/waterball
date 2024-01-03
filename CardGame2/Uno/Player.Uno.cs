using Game.Uno;

namespace Game.Players
{
    internal interface IUnoOperation
    {
        void SetUnoHand(IUnoHand unoHand);
    }
    internal partial class Player : IUnoOperation
    {
        public IUnoHand UnoHand { get; set; }

        public void SetUnoHand(IUnoHand unoHand)
        {
            UnoHand = unoHand;
        }
    }
}
