namespace _8.TicketSystem
{
    internal class TicketSystem3
    {
        private const int PRICE = 3;
        private int _total;
        private int _tickets;
        private bool lighton = false;
        private State _state;

        public TicketSystem3(int tickets) 
        {
            _tickets = tickets;
            _state = new InStockState(this, tickets);
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

        public void SetTotal(int total)
        {
            _total = total;
        }

        public void updateCoinsDisplay()
        {
            Console.WriteLine($"Total Coins: {_total}");
        }

        public void InsertCoin()
        {
            Console.WriteLine("[Action insert a coin]");
            _state.InsertCoin();
        }

        public void TurnLight(bool on)
        {
            lighton = on;
            var sign = on ? "on" : "off";
            Console.WriteLine($"The light is {sign}");
        }

        public void issueOneTicket()
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

        public void EnterState(State state)
        {
            _state.ExitState();
            _state = state;
            Console.WriteLine($"State updated: {state}");
            _state.EnterState();
        }
        public void PressBuyButton()
        {
            _state.PressBuyButton();
        }

        public void PressRefundButton()
        {
            Console.WriteLine($"[Action] Press the refund button.");
            _state.PressRefundButton();
        }
    }
}