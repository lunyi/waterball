namespace _8.TicketSystem
{
    internal class TicketSystem1
    {
        private const int PRICE = 3;
        private int total;
        private int Tickets;
        private bool lighton = false;

        public TicketSystem1(int ticekts) 
        {
            Tickets = ticekts;
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

        public void InsertCoin()
        {
            Console.WriteLine("[Action insert a coin]");
            if (total >= PRICE)
            {
                Console.WriteLine("[Error] You can't insert coins after the number of coins is enough.");
            }
            else
            { 
                total++;
                if (Tickets > 0)
                {
                    updateCoinsDisplay();
                    if (total == PRICE)
                    {
                        turnLight(true);
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

            if (lighton)
            {
                total -= PRICE;
                updateCoinsDisplay() ;
                issueOneTicket();
                turnLight(false);
            }
            else 
            {
                Console.WriteLine($"[Error] You haven't inserted enough coins.");
            }
        }

        private void issueOneTicket()
        {
            Tickets--;
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
            if (tickets > 0)
            {
                Console.WriteLine($"[Action] Fill in tickets: {tickets}");
                Tickets += tickets;
            }
        }
    }
}