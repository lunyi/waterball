using static _8.TicketSystem.TicketSystem2;

namespace _8.TicketSystem
{
    internal class TicketSystem3
    {
        private const int PRICE = 3;
        private int _total;
        private int _tickets;
        private bool lighton = false;
        private State _state;

        public TicketSystem3(int ticekts) 
        {
            _tickets = ticekts;
        }


        public void SetTickets(int tickets)
        {
            _tickets = tickets;
        }
        public int GetTickets()
        { 
            return _tickets;
        }
        public int GetTotal()
        {
            return _total;
        }
        public void updateCoinsDisplay()
        {
            Console.WriteLine($"Total Coins: {_total}");
        }

        public void turnLight(bool on)
        { 
            lighton = on;
            var sign = on ? "on" : "off";
            Console.WriteLine($"The light is {sign}");
        }

        public void EnterState(State state)
        {
            _state.ExitState();
            _state = state;
            Console.WriteLine($"State updated: {state}");
            _state.EnterState();
        }

        public void InsertCoin()
        {
            Console.WriteLine("[Action insert a coin]");
            _state.InsertCoin();
        }

        private void issueOneTicket()
        {
            Console.WriteLine($"You have bought one ticket.");
            if (--_tickets == 0)
            {
                EnterState(new SoldOutState(this));
            } 
            else if ( _total < PRICE)
            {
                EnterState(new InStockState(this, _tickets));
            }        
        }

        public void SpitCoins(int coins)
        {
            _total -= coins;
            Console.WriteLine($"Spitting the coins: {coins}");
        }

        public void PressRefundButton()
        {
            Console.WriteLine($"[Action] Press the refund button.");
            _state.PressRefundButton();
        }
    }

    internal class InStockState : State
    {
        private TicketSystem3 ticketSystem3;
        private int tickets;

        public InStockState(TicketSystem3 ticketSystem3, int tickets)
        {
            this.ticketSystem3 = ticketSystem3;
            this.tickets = tickets;
        }

        public override void InsertCoin()
        {
            throw new NotImplementedException();
        }

        public override void PressBuyButton()
        {
            throw new NotImplementedException();
        }
    }

    internal class SoldOutState : State
    {
        public SoldOutState(TicketSystem3 ticketSystem3) : base(ticketSystem3)
        {
        }

        public override void InsertCoin()
        {
            _ticketSystem3.set
        }

        public override void PressBuyButton()
        {
            throw new NotImplementedException();
        }
    }

    internal abstract class State
    {
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

        public void EnterState()
        { 
        
        }
        public void ExitState()
        {

        }

        public void FillInTickets(int tickets)
        {
            _ticketSystem3.SetTickets(_ticketSystem3.GetTickets() + tickets);
        }

        public void PressRefundButton()
        {
            _ticketSystem3.SpitCoins(_ticketSystem3.GetTotal());
        }
    }
}