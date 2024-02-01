
namespace CardGame.Base
{
    internal abstract class Player<Card>
    {
        static protected Random random = new Random();
        protected int Point;
        public int Index { get; protected set; }
        public string Name { get; protected set; }
        
        public Game<Card>? Game { get; internal set; }
        public Hand<Card>? Hand { get; internal set; }

        public Player(int index)
        {
            Hand = new Hand<Card>();
            Index = index;
        }

        public abstract void Naming();
        public void AddHandCard(Card card)
        {
            Hand.AddHandCard(card);
        }
    }
}
