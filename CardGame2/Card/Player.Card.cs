using Game.Card;
using System;

namespace Game.Players
{
    internal interface ICardOperation
    {
        Card<Rank, Suit>[] ShowCards();
        void AddHandCard(dynamic card);
        void DrawCard();
        int AddPoint();
        int GetPoint();
        void ChangeHandBack();
        bool CheckIfPlayerWantToExchangeCard(IList<Player> players);
        void Clear();
        void InitCard();
    }
    internal partial class Player : ICardOperation
    {
        private int Point;
        public IExchangeHands ExchangeHands { get; protected set; }
        public IHandCard Hand { get; internal set; }

        public Card<Rank, Suit>[] ShowCards()
        {
            return Hand.ShowCards();
        }

        public void AddHandCard(dynamic card)
        {
            Hand.AddHandCard(card);
        }

        public void DrawCard()
        {
            Hand.SelectCard(r.Next(1, Hand.Size()));
        }

        public int AddPoint()
        {
            return Point++;
        }

        public int GetPoint()
        {
            return Point;
        }

        public void ChangeHandBack()
        {
            ExchangeHands.ChangeHandBack();
        }

        public bool CheckIfPlayerWantToExchangeCard(IList<Player> players)
        {
            return ExchangeHands.CheckIfPlayerWantToExchangeCard(this, players);
        }

        public void Clear()
        {
            Hand?.ClearCards();
            ExchangeHands?.Clear();
            Point = 0;
        }

        public void InitCard()
        {
            Hand = new HandCard();
            Hand.SetPlayer(this);
            ExchangeHands = new ExchangeHands();
        }
    }

    internal static class PlayerExtensions
    {
        public static (string[], int) GetCardWinner(this IList<Player> players)
        {
            var point = players.Max(player => player.GetPoint());
            var playerNames = players.Where(p => p.GetPoint() == point)
                .Select(p => p.Name)
                .ToArray();
            return (playerNames, point);
        }
    }
}
