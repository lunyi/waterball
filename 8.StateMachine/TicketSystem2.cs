namespace _8.TicketSystem
{
    internal class TicketSystem2
    {
        private const int PRICE = 3;
        private int total;
        private int _tickets;
        private bool lighton = false;
        private StateEnum _state;

        public TicketSystem2(int ticekts) 
        {
            _tickets = ticekts;
            _state = (ticekts == 0) ? StateEnum.SOLD_OUT: StateEnum.IN_STOCK;
        }

        public enum StateEnum
        { 
            IN_STOCK, SOLD_OUT, ENOUGH_COINS
        }
        public void updateCoinsDisplay()
        {
            Console.WriteLine($"Total Coins: {total}");
        }

        public void turnLight(bool on)
        { 
            lighton = on;
            var sign = on ? "on" : "off";
            Console.WriteLine($"The light is {sign}");
        }

        public void EnterState(StateEnum state)
        {
            if (_state == StateEnum.ENOUGH_COINS)
            {
                turnLight(false);
            }
            _state = state;
            Console.WriteLine($"State updated: {state}");

            if (_state == StateEnum.ENOUGH_COINS)
            {
                total = PRICE;
                turnLight(true);
            }
            if (_state == StateEnum.IN_STOCK && total >= PRICE)
            {
                spitCoins(PRICE - total - 1);
            }
            else if (state == StateEnum.SOLD_OUT && total != 0)
            {
                spitCoins(total);
            }

            if (state == StateEnum.SOLD_OUT)
            {
                _tickets = 0;
            }

            if ((_state == StateEnum.IN_STOCK || _state == StateEnum.ENOUGH_COINS) && _tickets <= 0)
            {
                throw new Exception("Cannot enter IN_STOCK or ENOUGH_COINS state if tickets == 0");
            }
        }

        public void InsertCoin()
        {
            Console.WriteLine("[Action insert a coin]");
            if (_state == StateEnum.ENOUGH_COINS)
            {
                Console.WriteLine("[Error] You can't insert coins after the number of coins is enough.");
            }
            else
            { 
                total++;
                if (_state == StateEnum.IN_STOCK)
                {
                    updateCoinsDisplay();
                    if (total >= PRICE)
                    {
                        EnterState(StateEnum.ENOUGH_COINS);
                    }
                }
                else
                {
                    spitCoins(total);
                }
            }
        }

        public void PressBuyButton()
        {
            Console.WriteLine($"[Action] Press the buy button.");

            if (_state == StateEnum.ENOUGH_COINS)
            {
                total -= PRICE;
                updateCoinsDisplay() ;
                issueOneTicket();
            }
            else 
            {
                Console.WriteLine($"[Error] You haven't inserted enough coins.");
            }
        }

        private void issueOneTicket()
        {
            if (--_tickets == 0)
            {
                EnterState(StateEnum.SOLD_OUT);
            } 
            else if ( total < PRICE)
            {
                EnterState(StateEnum.IN_STOCK);
            }
            Console.WriteLine($"You have bought one ticket.");
        }

        private void spitCoins(int coins)
        {
            if (coins > 0)
            { 
                total -= coins;
                Console.WriteLine($"Spitting the coins: {coins}");
            }
        }

        public void PressRefundButton()
        {
            Console.WriteLine($"[Action] Press the refund button.");
            spitCoins(total);
            if (lighton)
            {
                turnLight(false);
            }
        }

        public void FillTickets(int tickets) 
        {
            Console.WriteLine($"[Action] Fill in tickets: {tickets}");
            _tickets += tickets;

            if (_state == StateEnum.SOLD_OUT)
            {
                EnterState(StateEnum.IN_STOCK);
            }
        }
    }
}