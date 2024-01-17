namespace _8.TicketSystem
{
    internal class EnoughCoinsState : State
    {
        public EnoughCoinsState(TicketSystem3 ticketSystem3) : base(ticketSystem3)
        {
        }

        public override void EnterState()
        {
            if (_ticketSystem3.GetTickets() <= 0)
            {
                throw new Exception("Cannot enter ENOUGH_COINS state if ticket <= 0");
            }

            _ticketSystem3.SetTotal(PRICE);
            _ticketSystem3.TurnLight(true);
        }

        public override void ExitState()
        {
            _ticketSystem3.TurnLight(false);
        }


        public override void InsertCoin()
        {
            Console.WriteLine("[ERROR] You can't insert coins after the number of coins is enough");
        }

        public override void PressBuyButton()
        {
            _ticketSystem3.SetTotal(_ticketSystem3.GetTotal() - PRICE);
            _ticketSystem3.updateCoinsDisplay();
            _ticketSystem3.issueOneTicket();
        }

        public override void PressRefundButton()
        {
            _ticketSystem3.SpitCoins(_ticketSystem3.GetTotal());
            _ticketSystem3.EnterState(new InStockState(_ticketSystem3));
        }
    }
}