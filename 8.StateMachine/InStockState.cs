using _8.StateMachine;

namespace _8.TicketSystem
{
    internal class InStockState : State
    {
        public InStockState(TicketSystem3 ticketSystem3, int tickets) : base(ticketSystem3, tickets)
        {
            _ticketSystem3.SetTickets(tickets);
        }

        public InStockState(TicketSystem3 ticketSystem3) : base(ticketSystem3)
        {

        }

        public override void EnterState()
        {
            if (_ticketSystem3.GetTotal() >  PRICE)
            {
                _ticketSystem3.SpitCoins(PRICE - _ticketSystem3.GetTotal() -1);
            }

            if (_ticketSystem3.GetTickets() <= 0)
            {
                throw new Exception("Cannot enter IN_STOCK or ENOUGH or ENOUGH_COINS state");
            }
        }

        public override void InsertCoin()
        {
            _ticketSystem3.SetTotal(_ticketSystem3.GetTotal() + 1);
            _ticketSystem3.updateCoinsDisplay();

            if (PRICE == _ticketSystem3.GetTotal())
            {
                _ticketSystem3.EnterState(new EnoughCoinsState(_ticketSystem3));
            }
        }

        public override void PressBuyButton()
        {
            Console.WriteLine("[Error] You haven't inserted enough coins.");
        }
    }
}