namespace _8.StatePattern
{
    internal class State
    {
        public int _round;
        private Role _role;

        public State()
        {
        }

        public void SetRole(Role role)
        {
            _role = role;
        }
        public void DeductRound()
        {
            _round--;
        }
    }
}
