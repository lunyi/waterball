namespace _8.TicketSystem
{
    internal abstract class State
    {
        protected const int PRICE = 3;
        protected TicketSystem3 _ticketSystem3;

        public State(TicketSystem3 ticketSystem3)
        {
            _ticketSystem3 = ticketSystem3;
        }

        public State(TicketSystem3 ticketSystem3, int ticket)
        {
            _ticketSystem3 = ticketSystem3;
        }

        public abstract void InsertCoin();
        public abstract void PressBuyButton();

        public virtual void EnterState()
        {

        }
        public virtual void ExitState()
        {

        }

        public virtual void FillInTickets(int tickets)
        {
            _ticketSystem3.SetTickets(_ticketSystem3.GetTickets() + tickets);
        }

        public virtual void PressRefundButton()
        {
            _ticketSystem3.SpitCoins(_ticketSystem3.GetTotal());
        }
    }
}
