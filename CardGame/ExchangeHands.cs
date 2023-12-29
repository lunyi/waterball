namespace CardGame
{
    internal interface IExchangeHands
    {
        void ExchangeHand(Player exchanger, Player exchangee);
        void CountDown();
        int GetCountDown();
    }
    internal class ExchangeHands : IExchangeHands
    {     
        private int countDown = 3;
        private Player? _exchanger = null;
        private Player? _exchangee = null;

        public ExchangeHands()
        { 
        }


        public void ExchangeHand(Player exchanger, Player exchangee)
        {
            (_exchanger, _exchangee) = (exchanger, exchangee);
            (_exchanger._hand, _exchangee._hand) = (exchangee._hand, exchanger._hand);
            countDown--;
        }
        public void CountDown()
        {
            countDown--;
            if (countDown == 0)
            {
                (_exchanger._hand, _exchangee._hand) = (_exchangee._hand, _exchanger._hand);
                Console.WriteLine($"{_exchanger.GetPlayerName()} and {_exchangee.GetPlayerName()} are changed back");
            }
        }

        public int GetCountDown() 
        {
            return countDown;
        }
    }
}
