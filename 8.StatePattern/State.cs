namespace _8.StatePattern
{
    internal class State
    {
        public int _round;
        private Character _character;

        public State(Character character)
        {
            _character = character;
        }

        public void DeductRound()
        {
            _round--;
        }
    }
}
