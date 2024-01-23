using CardGame.Common;

namespace CardGame.Common
{
    internal class AIPlayer<TSuit, TRank> : Player<TSuit, TRank>
        where TSuit : Enum
        where TRank : Enum
    {
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }

        public override Card<TSuit, TRank> SelectCard(TSuit suit)
        {
            throw new NotImplementedException();
        }
    }
}
