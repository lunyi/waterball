using _8.StateMachine;

namespace _8.TicketSystem
{
    internal class SoldOutState : State
    {
        public SoldOutState(TicketSystem3 ticketSystem3) : base(ticketSystem3)
        {
        }

        public override void EnterState()
        {
            if (_ticketSystem3.GetTotal() != 0)
            {
                _ticketSystem3.SpitCoins(_ticketSystem3.GetTotal());
            }

            _ticketSystem3.SetTickets(0);
        }

        public override void InsertCoin()
        {
            _ticketSystem3.SetTotal(_ticketSystem3.GetTotal() + 1);
            _ticketSystem3.SpitCoins(_ticketSystem3.GetTotal());
        }

        public override void PressBuyButton()
        {
            Console.WriteLine("[ERROR] You haven't inserted enough coins");
        }

        public override void FillInTickets(int tickets)
        {
            _ticketSystem3.EnterState(new InStockState(_ticketSystem3, _ticketSystem3.GetTickets() + tickets));
        }
    }
}