using System.Xml.Linq;

namespace Game
{
    internal interface IExchangeHands
    {
        void ExchangeHand(Player exchanger, Player exchangee);
        void CountDown();
        int GetCount();
        bool CheckIfPlayerWantToExchangeCard(Player player, IList<Player> players);
        void ChangeHandBack();
        bool IsChangeBack();
        void Clear();
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
            if (!_isChangeBack)
            {
                return;
            }

            (_exchanger.Hand, _exchangee.Hand) = (_exchangee.Hand, _exchanger.Hand);

            var tmpPayer = _exchanger.Hand.GetPlayer();
            _exchanger.Hand.SetPlayer(_exchangee.Hand.GetPlayer());
            _exchangee.Hand.SetPlayer(tmpPayer);

            Console.WriteLine($"{_exchanger.Name} and {_exchangee.Name} are changed back");
            _isChangeBack = false;
            Thread.Sleep(2000);
        }

        public bool CheckIfPlayerWantToExchangeCard(Player player, IList<Player> players)
        {
            if (GetCount() == 3)
            {
                Console.WriteLine($"Hi {player.Name}, which player do you choose to exchange hand?");
                try
                {
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != player._index && playerIndex >= 1 && playerIndex <= 4)
                    {
                        var exchangee = players.FirstOrDefault(p => p._index == playerIndex);
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
            else
            {
                CountDown();
            }
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
