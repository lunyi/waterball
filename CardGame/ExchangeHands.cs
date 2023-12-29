namespace CardGame
{
    internal class ExchangeHands
    {     
        private int countDown = 3;
        private Player? _exchanger = null;
        private Player? _exchangee = null;

        public void ExchangeHand(Player exchanger, Player exchangee)
        {
            (_exchanger, _exchangee) = (_exchangee, exchangee);
            (exchanger.Hand, exchangee.Hand) = (exchangee.Hand, exchanger.Hand);
        }
        public void CountDown()
        {
            countDown--;
            if (countDown == 0)
            {
                (_exchanger.Hand, _exchangee.Hand) = (_exchangee.Hand, _exchanger.Hand);
            }
        }

        public int GetCountDown() 
        {
            return countDown;
        }
    }
}
