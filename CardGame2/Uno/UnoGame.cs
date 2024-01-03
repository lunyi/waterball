using Game.Players;

namespace Game.Uno
{
    internal class UnoGame
    {
        private int CardCount = 5;
        private Card<RankUno,SuitUno> _tmpCards;

        private IDeck<Card<RankUno, SuitUno>, RankUno, SuitUno> _deck;
        private IList<Player> _players;

        public UnoGame(IDeck<Card<RankUno, SuitUno>, RankUno, SuitUno> deck, IList<Player> players)
        {
            _deck = deck;
            _players = players;
        }

        public void Start()
        {
            var quit = false;
            while (!quit)
            {
                initPlayerCards();
                var card = _deck.DrawCard();

                var topPosition = 2;

                for (int i = 0; i < _players.Count; i++)
                {
                    var cards = _players[i].UnoHand.GetCards();

                    Console.SetCursorPosition(0, topPosition);
                    Console.ForegroundColor = _players[i] is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.Yellow;
                    Console.WriteLine($"{_players[i].Index}: {_players[i].Name}");


                    for (int j = 0; j < cards.Length; j++)
                    {
                        var c = new Card<RankUno, SuitUno>(cards[j].Suits, cards[j].Ranks);
                        DisplayUno.DrawCard(c, 2 * j , topPosition + 1);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    topPosition = topPosition + 7;


                }
                Console.ReadKey();
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
                var unoPlayer = player as IUnoOperation;
                unoPlayer.SetUnoHand(new UnoHand());

                for (int i = 0; i < CardCount; i++)
                {
                    unoPlayer.AddUnoCard(_deck.DrawCard());
                }
            }
        }
    }
}
