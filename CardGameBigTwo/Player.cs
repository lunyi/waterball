namespace CardGame
{
    internal abstract class Player 
    {
        static protected Random r = new Random();
        public int Index { get; protected set; }
        public int OrderIndex { get; set; }
        public string Name { get; protected set; }
        public Hand Hand { get; internal set; }
        public abstract void SelectCard();
        public abstract void Naming(string name);

        public Player(int index)
        {
            Hand = new Hand();
            Hand.Player = this;
            Index = index;
        }

        public List<Card> ShowCards()
        {
            return Hand.ShowCards();
        }

        public void AddHandCard(Card card)
        {
            Hand.AddHandCard(card);
        }

        public void DrawCard()
        {
            Hand.SelectCard(r.Next(1, Hand.Size()));
        }

        public void Clear()
        {
            Hand.ClearCards();
        }

        public void DisplayTurn()
        {
            Console.WriteLine($"輪到 {this.Name}, {this.Index}, {this.OrderIndex}");
        }

        public List<Card> ShowFirstCards()
        {
            var cards = Hand.ShowCards();
            var beginCard = cards[0];


            var showCards = cards.GetStraightFlush(beginCard) ;
            if (showCards == null)
            {
                showCards = cards.GetFourOfAKind(beginCard);
            }
            if (showCards == null)
            {
                showCards = cards.GetStraight(beginCard, (_this, _that) => _this.Equals(beginCard));
            }
            if (showCards == null)
            {
                showCards = cards.GetFullHouse(beginCard, (_this, _that) => _this.Equals(beginCard));
            }
            if (showCards == null)
            {
                showCards = cards.GetPair(beginCard, (_this, _that ) => _this.Equals(beginCard));
            }
            if (showCards == null)
            {
                showCards = new List<Card> { beginCard };
            }

            RemoveCards(showCards);

            return showCards.SortCards();
        }

        public List<Card> ShowCards(List<Card> keyCards)
        {
            if (keyCards.Count == 0 || keyCards == null)
            {
                return keyCards;
            }
            List<Card> showCards = null;
            var cards = Hand.ShowCards();
            keyCards = keyCards.SortCards();

            var biggestCard = keyCards[keyCards.Count - 1];
            if (keyCards.Count == 5)
            {
                if (keyCards.IsStraightFlush())
                {
                    showCards = cards.GetStraightFlush(biggestCard, (_this, _that) => _this.GreatThan(biggestCard));
                }
                else if (keyCards.IsFourOfAKind())
                {
                    showCards = cards.GetFourOfAKind(biggestCard, (_this, _that) => _this.GreatThan(biggestCard));
                }
                else if (keyCards.IsStraight())
                {
                    showCards = cards.GetStraight(biggestCard, (_this, _that) => _this.GreatThan(biggestCard));
                }
                else if (keyCards.IsFullHouse())
                {
                    showCards = cards.GetFullHouse(biggestCard, (_this, _that) => _this.GreatThan(biggestCard));
                }
            }
            else if (keyCards.Count == 2)
            {
                showCards = cards.GetPair(keyCards[1], (_this, _that) => _this.GreatThan(keyCards[1]));
            }
            else if (keyCards.Count == 1)
            {
                showCards = cards.GetSingle(keyCards[0]);
            }

            RemoveCards(showCards);

            return showCards;
        }

        private void RemoveCards(List<Card> showCards)
        {
            if (showCards == null)
            {
                return;
            }
            for (int i = 0; i < showCards.Count; i++)
            {
                Hand.RemoveCard(showCards[i]);
            }
        }
    }

    internal static class PlayerExtensions
    {
        internal static void SetPlayersOrder(this IList<Player> players, int startingIndex)
        {
            int orderIndex = 1;
            int totalPlayers = players.Count;

            for (int i = 0; i < totalPlayers; i++)
            {
                int currentIndex = (startingIndex + i - 1) % totalPlayers;
                players.First(p => p.Index == currentIndex + 1).OrderIndex = orderIndex++;
            }
        }
    }
}
