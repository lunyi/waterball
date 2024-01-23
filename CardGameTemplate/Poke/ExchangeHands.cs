using CardGame.Common;

namespace CardGame.Poke
{
    internal class ExchangeHands
    {     
        private int countDown = 3;
        private Player<Suit, Rank>? _exchanger = null;
        private Player<Suit, Rank>? _exchangee = null;

        public ExchangeHands(Player<Suit, Rank> exchanger, Player<Suit, Rank> exchangee)
        {
            _exchanger = exchanger;
            _exchangee = exchangee;
            exchange();
           
        }

        private void exchange(bool isback=false)
        {
            Console.WriteLine($"exchanger: {_exchanger.Name}, exchangee: {_exchangee.Name} isback: {isback}");
            var hand = _exchanger.Hand;
            _exchanger.Hand = _exchangee.Hand;
            _exchangee.Hand = hand;
        }

        public void CountDown()
        {
            countDown--;
            if (countDown == 0)
            {
                exchange(true);
            }
        }
    }
}
