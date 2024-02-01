using CardGame.Common;

namespace CardGame.Uno
{
    internal class AIPlayer : Player
    {
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }
    }
}
