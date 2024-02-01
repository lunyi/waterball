namespace CardGame.Showdown
{
    internal class AIPlayer: Player
    {
        private static Random Random = new Random();
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }

        public override Card SelectCard()
        {
            var cards = Hand.ShowCards();
            var card = cards[Random.Next(cards.Length)];
            Hand.Remove(card);
            return card;
        }
    }
}
