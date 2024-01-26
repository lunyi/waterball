using CardGame.Uno;

namespace CardGame.Common
{
    internal abstract class Game<TSuit, TRank>
        where TSuit : Enum
        where TRank : Enum
    {
        protected readonly IDeck<TSuit, TRank> _deck;
        protected readonly Player<TSuit, TRank>[] _players;

        public Game(IDeck<TSuit, TRank> deck, Player<TSuit, TRank>[] players)
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

        public Player<TSuit, TRank>[] GetPlayers()
        {
            return _players;
        }
    }
}
