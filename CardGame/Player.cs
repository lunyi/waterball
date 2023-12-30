﻿namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        private int Point ;
        public int _index { get; set; }
        protected string Name ;
        protected IExchangeHands _exchangeHands { get; set; }
        public IHand Hand { get; set; }
        public abstract void TakeTurns();
        public abstract void NameHimself(string name);


        public Player(int index)
        {
            Hand = new Hand();
            Hand.SetPlayer(this);
            _index = index;
            _exchangeHands = new ExchangeHands();
        }

        public void ChangeHandBack()
        {
            _exchangeHands.ChangeHandBack();
        }
        public bool IsChangeBack()
        { 
            return _exchangeHands.IsChangeBack();
        }

        public bool MakeExchangeHandsDecision(IList<Player> players)
        {
            if (_exchangeHands.GetCountDown() == 3)
            {
                Console.WriteLine($"Hi {Name}, which player do you choose to exchange hand?");
                try
                {
                    var playerIndex = Convert.ToInt32(Console.ReadLine());
                    if (playerIndex != _index && playerIndex>= 1 && playerIndex<=4)
                    {
                        var exchangee = players.FirstOrDefault(p => p._index == playerIndex);
                        _exchangeHands.ExchangeHand(this, exchangee);
                        return true;
                    }
                }
                catch
                {
                }

                Console.WriteLine($"Ok, {Name} doesn't want to change.");
                Console.WriteLine();
                return false;
            }
            else
            {
                _exchangeHands.CountDown();
            }
            return false;
        }

        public Card[] ShowCards()
        {
            return Hand.ShowCards();
        }

        public void Clear()
        {
            Hand.ClearCards();
            _exchangeHands.Clear();
            Point = 0;
        }

        public void AddHandCard(Card card)
        {
            Hand.AddHand(card);
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public void TakeTurn()
        {
            Hand.PickupCard(r.Next(1, Hand.Size()));
        }

        public int AddPoint()
        {
            return Point++;
        }

        public int GainPoint()
        {
            return Point;
        }
    }

    internal static class PlayerExtensions
    {
        public static (string[], int) GetFinalWinner(this IList<Player> players)
        {
            var point = players.Max(player => player.GainPoint());
            var playerNames = players.Where(p => p.GainPoint() == point)
                .Select(p=>p.GetPlayerName())
                .ToArray();
            return (playerNames, point);
        }
    }
}
