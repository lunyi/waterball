using _8.TicketSystem;
using static _8.TicketSystem.TicketSystem2;

namespace _8.StateMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunTicketSystem3();
        }

        static void RunTicketSystem3()
        {
            var ticketSystem = new TicketSystem3(2);
            Console.WriteLine("[Case 1] Enough coins -> Error 不再接受新硬幣");
            ticketSystem.EnterState(new EnoughCoinsState(ticketSystem));
            ticketSystem.InsertCoin();
            Console.WriteLine();

            Console.WriteLine("[Case 2] 3 coins + refund -> 吐3枚, 熄燈");
            ticketSystem.PressRefundButton();
            Console.WriteLine();

            Console.WriteLine("[Case 3] 3 coins + Buy -> 將硬幣總數歸零，出一張票，熄燈");
            ticketSystem.EnterState(new EnoughCoinsState(ticketSystem));
            ticketSystem.PressBuyButton();
            Console.WriteLine();

            Console.WriteLine("[Case 4] 0 coins + buy -> Error 金幣不足");
            ticketSystem.EnterState(new InStockState(ticketSystem));
            ticketSystem.PressBuyButton();
            Console.WriteLine();

            Console.WriteLine("[Case 5] 0 coins + Refund -> 吐 0 枚");
            ticketSystem.PressRefundButton();
            Console.WriteLine();

            Console.WriteLine("[Case 6] 0 tickets + Insert Coin -> 立即吐出1枚硬幣");
            ticketSystem.EnterState(new SoldOutState(ticketSystem));
            ticketSystem.InsertCoin();
            Console.ReadLine();
        }

        static void RunTicketSystem2()
        {
            var ticketSystem = new TicketSystem2(2);
            Console.WriteLine("[Case 1] Enough coins -> Error 不再接受新硬幣");
            ticketSystem.EnterState(StateEnum.ENOUGH_COINS);
            ticketSystem.InsertCoin();
            Console.WriteLine();

            Console.WriteLine("[Case 2] 3 coins + refund -> 吐3枚, 熄燈");
            ticketSystem.PressRefundButton();
            Console.WriteLine();

            Console.WriteLine("[Case 3] 3 coins + Buy -> 將硬幣總數歸零，出一張票，熄燈");
            ticketSystem.EnterState(StateEnum.ENOUGH_COINS);
            ticketSystem.PressBuyButton();
            Console.WriteLine();

            Console.WriteLine("[Case 4] 0 coins + buy -> Error 金幣不足");
            ticketSystem.EnterState(StateEnum.IN_STOCK);
            ticketSystem.PressBuyButton();
            Console.WriteLine();

            Console.WriteLine("[Case 5] 0 coins + Refund -> 吐 0 枚");
            ticketSystem.PressRefundButton();
            Console.WriteLine();

            Console.WriteLine("[Case 6] 0 tickets + Insert Coin -> 立即吐出1枚硬幣");
            ticketSystem.EnterState(StateEnum.SOLD_OUT);
            ticketSystem.InsertCoin();
            Console.ReadLine();
        }

        static void RunTicketSsystem1()
        {
            var ticketSystem = new TicketSystem1(2);
            Console.WriteLine("[Case 1] Enough coins -> Error 不再接受新硬幣");
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            Console.WriteLine();

            Console.WriteLine("[Case 2] 3 coins + refund -> 吐3枚, 熄燈");
            ticketSystem.PressRefundButton();
            Console.WriteLine();

            Console.WriteLine("[Case 3] 3 coins + Buy -> 將硬幣總數歸零，出一張票，熄燈");
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            ticketSystem.PressBuyButton();
            Console.WriteLine();

            Console.WriteLine("[Case 4] 0 coins + buy -> Error 金幣不足");
            ticketSystem.PressBuyButton();
            Console.WriteLine();

            Console.WriteLine("[Case 5] 0 coins + Refund -> 吐 0 枚");
            ticketSystem.PressRefundButton();
            Console.WriteLine();

            Console.WriteLine("[Case 6] 0 tickets + Insert Coin -> 立即吐出1枚硬幣");
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            ticketSystem.PressBuyButton();
            ticketSystem.InsertCoin();
            ticketSystem.InsertCoin();
            Console.ReadLine();
        }
    }
}