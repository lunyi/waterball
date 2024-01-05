namespace CardGame
{
    internal interface IExchangeHands
    {
        void ExchangeHand(Player exchanger, Player exchangee);
        void CountDown();
        int GetCount();
        void ChangeHandBack();
        void Clear();
        bool CheckIfPlayerWantToExchangeCard(Player player, IList<Player> players);
    }
    internal class ExchangeHands : IExchangeHands
    {     
        private int countDown = 3;
        private Player? _exchanger = null;
        private Player? _exchangee = null;
        private bool _isChangeBack = false;

        public ExchangeHands()
        { 
        }

        public void ExchangeHand(Player exchanger, Player exchangee)
        {
            (_exchanger, _exchangee) = (exchanger, exchangee);
            (_exchanger.Hand, _exchangee.Hand) = (exchangee.Hand, exchanger.Hand);

            SwapPlayers(_exchanger.Hand.Player, _exchangee.Hand.Player);
            //var tmpPayer = _exchanger.Hand.Player;
            //_exchanger.Hand.Player = _exchangee.Hand.Player;
            //_exchangee.Hand.Player = tmpPayer;

            countDown--;
        }

        public void ChangeHandBack()
        {
            if (!_isChangeBack)
            {
                return;
            }
            (_exchanger.Hand, _exchangee.Hand) = (_exchangee.Hand, _exchanger.Hand);

            SwapPlayers(_exchanger.Hand.Player, _exchangee.Hand.Player);

            //var tmpPayer = _exchanger.Hand.Player;
            //_exchanger.Hand.Player = _exchangee.Hand.Player;
            //_exchangee.Hand.Player = tmpPayer;

            Console.WriteLine($"{_exchanger.Name} and {_exchangee.Name} are changed back");
            _isChangeBack = false;
            Thread.Sleep(2000);
        }

        private void SwapPlayers(Player firstPlayer, Player secondPlayer)
        {
            Swap(ref firstPlayer, ref secondPlayer);
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            (first, second) = (second, first);
        }

        public void CountDown()
        {
            countDown--;
            if (countDown == 0)
            {
                _isChangeBack = true;
            }
        }

        public bool CheckIfPlayerWantToExchangeCard(Player player, IList<Player> players)
        {
            if (GetCount() != 3)
            {
                CountDown();
            }

            Console.WriteLine($"Hi {player.Name}, which player do you choose to exchange hand?");
            try
            {
                var playerIndex = Convert.ToInt32(Console.ReadLine());
                if (playerIndex != player.Index && playerIndex >= 1 && playerIndex <= 4)
                {
                    var exchangee = players.FirstOrDefault(p => p.Index == playerIndex);
                    ExchangeHand(player, exchangee);
                    return true;
                }
            }
            catch
            {
            }

            Console.WriteLine($"Ok, {player.Name} doesn't want to change.");
            Console.WriteLine();
            return false;
        }

        public int GetCount() 
        {
            return countDown;
        }

        public void Clear()
        {
            countDown = 3;
        }
    }
}
