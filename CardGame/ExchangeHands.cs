namespace CardGame
{
    internal interface IExchangeHands
    {
        void ExchangeHand(Player exchanger, Player exchangee);
        void CountDown();
        int GetCountDown();
        void ChangeHandBack();
        bool IsChangeBack();
        void Clear();
    }
    internal class ExchangeHands : IExchangeHands
    {     
        private int countDown = 3;
        private Player? _exchanger = null;
        private Player? _exchangee = null;
        public bool _isChangeBack = false;

        public ExchangeHands()
        { 
        }


        public void ExchangeHand(Player exchanger, Player exchangee)
        {
            (_exchanger, _exchangee) = (exchanger, exchangee);
            (_exchanger.Hand, _exchangee.Hand) = (exchangee.Hand, exchanger.Hand);
            
            var tmpPayer = _exchanger.Hand.GetPlayer();
            _exchanger.Hand.SetPlayer(_exchangee.Hand.GetPlayer());
            _exchangee.Hand.SetPlayer(tmpPayer);

            countDown--;
        }
        public void CountDown()
        {
            countDown--;
            if (countDown == 0)
            {
                _isChangeBack = true;
            }
        }
        public bool IsChangeBack()
        {
            return _isChangeBack;
        }

        public void ChangeHandBack()
        {
            //TODO:　add a flag to change hand back
            (_exchanger.Hand, _exchangee.Hand) = (_exchangee.Hand, _exchanger.Hand);

            var tmpPayer = _exchanger.Hand.GetPlayer();
            _exchanger.Hand.SetPlayer(_exchangee.Hand.GetPlayer());
            _exchangee.Hand.SetPlayer(tmpPayer);

            Console.WriteLine($"{_exchanger.GetPlayerName()} and {_exchangee.GetPlayerName()} are changed back");
            _isChangeBack = false;
            Thread.Sleep(2000);
        }
        public int GetCountDown() 
        {
            return countDown;
        }

        public void Clear()
        {
            countDown = 3;
        }
    }
}
