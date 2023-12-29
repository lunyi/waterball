namespace CardGame
{
    internal class ExchangeHands
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
            (_exchanger.Hand, _exchangee.Hand) = (exchangee.Hand, exchanger.Hand);
            countDown--;
        }
        public void CountDown()
        {
            countDown--;
            if (countDown == 0)
            {
                (_exchanger.Hand, _exchangee.Hand) = (_exchangee.Hand, _exchanger.Hand);
                Console.WriteLine($"{_exchanger.GetPlayerName()} and {_exchangee.GetPlayerName()} are changed back");
            }
        }

        public int GetCountDown() 
        {
            return countDown;
        }
    }
}
