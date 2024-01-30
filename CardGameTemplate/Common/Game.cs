namespace CardGame.Common
{
    internal abstract class Game<Card>
    {
        protected readonly Deck<Card> _deck;
        protected readonly Player<Card>[] _players;

        public Game(Deck<Card> deck, Player<Card>[] players)
        {
            _deck = deck;
            _players = players;
        }

        public abstract void Start();

        protected virtual void initPlayerCards(int CardQuantityInARount)
        {
            foreach (var player in _players)
            {
                player.Naming();
                player.Game = this;
            }

            _deck.Shuffle();

            foreach (var player in _players)
            {
                for (int i = 0; i < CardQuantityInARount; i++)
                {
                    player.AddHandCard(_deck.DrawCard());
                }
            }
        }

        public Player<Card>[] GetPlayers()
        {
            return _players;
        }
    }
}
