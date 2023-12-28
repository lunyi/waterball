using System;

namespace CardGame
{
    internal abstract class Player 
    {
        Random r = new Random();
        private int Point ;
        protected string Name ;
        protected bool exchangeHand = false ;
        private Hand hand ;

        public abstract void NameHimself(string name);
        public abstract bool makeExchangeHandsDecision();

        public Player()
        {
            hand = new Hand();
            hand.Player = this;
        }

        public Hand GetHand()
        {
            return hand;
        }

        public Card[] ShowCards()
        {
            return hand.ShowCards();
        }

        public bool GetExchangeHand()
        { 
            return exchangeHand;
        }
        public void SetExchangeHand()
        {
            exchangeHand = true;
        }

        public void AddHandCard(Card card)
        {
            hand.AddHand(card);
        }

        public string GetPlayerName()
        {
            return Name;
        }

        public void TakeTurn()
        {
            hand.PickupCard(r.Next(1, hand.Size()));
        }

        public int AddPoint()
        {
            return Point++;
        }

        public int GainPoint()
        {
            return Point;
        }

        public void ExchangeHands(Player exchangee)
        { 

        }
    }

    internal static class PlayerExtensions
    {
        public static List<Hand> GetHands(this List<Player> players)
        {
            List<Hand> hands = new List<Hand>();

            foreach (Player player in players)
            {
                hands.Add(player.GetHand());
            }

            return hands;
        }
    }
}
