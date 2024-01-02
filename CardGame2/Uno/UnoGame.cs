
using Game;

namespace Game.Uno
{
    internal class UnoGame
    {
        private int CardCount = 5;
        private Card<RankUno,SuitUno> _tmpCards;

        private IDeck<UnoCard, RankUno, SuitUno> _deck;
        private IList<Player> _players;

        public UnoGame(IDeck<UnoCard, RankUno, SuitUno> deck, IList<Player> players)
        {
            _deck = deck;
            _players = players;
            //RountCount = Num_Of_Ranks = Enum.GetValues(typeof(RankUno)).Length;
        }

        public void Start()
        {
            var quit = false;
            while (!quit)
            {
                initPlayerCards();
                var card = _deck.DrawCard();
                
                for (int i = 0; i < _players.Count; i++) 
                { 
                    //if (_players[i])
                }
            }

            Console.ReadKey();
        }

        private void initPlayerCards()
        {
            
            foreach (var player in _players)
            {
                player.Clear();
            }

            _deck.Shuffle();

            foreach (var player in _players)
            {
                for (int i = 0; i < CardCount; i++)
                {
                    player.AddHandCard(_deck.DrawCard());
                }
            }
        }
    }
}
