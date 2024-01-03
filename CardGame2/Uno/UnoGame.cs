using Game.Players;

namespace Game.Uno
{
    internal class UnoGame
    {
        private int CardCount = 5;
        private IList<Card<RankUno,SuitUno>> _tmpCards = new List<Card<RankUno, SuitUno>>();

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
                var topPosition = 2;
                DisplayUno.DisplayCardsOfPlayers(_players, topPosition);
                var card = DrawCard();
                DisplayUno.DrawCard(card, 4 , topPosition + 1);

                for (int i = 0; i < _players.Count; i++)
                {
                    var _card = _players[i].UnoHand.GetCardBySuit(card.Suits);

                    if (_card==null)
                    {
                        var tmpCard = DrawCard();
                       
                        while (tmpCard.Suits != card.Suits)
                        {
                            Console.WriteLine("卡片不對");
                            _players[i].UnoHand.AddUnoCard(tmpCard);
                            tmpCard = DrawCard();
                        }
                    }
                    else
                    {
                        _tmpCards.Add(_card);
                    }
                }
                Console.ReadKey();
                checkIfFinal();
            }

            Console.ReadKey();
        }

        private Card<RankUno, SuitUno> DrawCard()
        {
            Card<RankUno, SuitUno> card = _deck.DrawCard();
            if (card == null)
            {
                Console.WriteLine("卡片沒了，重新換卡");
                Thread.Sleep(2000);
                _deck.Shuffle(_tmpCards.ToArray());
                _tmpCards.Clear();
                card = _deck.DrawCard();
            }
            return card;
        }
        private void checkIfFinal()
        {
            if (_players.Any(p => p.UnoHand.GetCardSize() > 0))
            {
                return;
            }
            Console.WriteLine("Game Over");
            var players = _players
                .Where(p=>p.UnoHand.GetCardSize()== 0)
                .Select(p=>p.Name).ToArray();

            Console.WriteLine("The winners is ");

            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($" {players[i]} ");
            }  
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
                player.SetUnoHand(new UnoHand());

                for (int i = 0; i < CardCount; i++)
                {
                    player.UnoHand.AddUnoCard(_deck.DrawCard());
                }
            }
        }
    }
}
