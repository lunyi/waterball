using Game.Players;

namespace Game.Uno
{
    internal class UnoGame
    {
        private int CardCount = 5;
        private IList<Card<RankUno, SuitUno>> _tmpCards = new List<Card<RankUno, SuitUno>>();

        private IDeck<Card<RankUno, SuitUno>, RankUno, SuitUno> _deck;
        private IList<Player> _players;

        public UnoGame(IDeck<Card<RankUno, SuitUno>, RankUno, SuitUno> deck, IList<Player> players)
        {
            _deck = deck;
            _players = players;
        }

        public void Start()
        {
            initPlayerCards();
            var countCalculate = new Dictionary<string, int>();
            var quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.ResetColor();
                RunEachRound(countCalculate);
                Console.ReadKey();
                countCalculate.Clear();
                checkIfFinal();
            }

            Console.ReadKey();
        }

        private void RunEachRound(Dictionary<string, int> countCalculate)
        {
            var topPosition = 2;
            topPosition = DisplayUno.DisplayCardsOfPlayers(_players, topPosition);
            var targetCard = GetTargetCard(topPosition);
            topPosition++;

            for (int i = 0; i < _players.Count; i++)
            {
                Console.Write($"    {_players[i].Name}      ");
            }
            topPosition += 8;
            for (int i = 0; i < _players.Count; i++)
            {
                var _card = _players[i].UnoHand.GetCardBySuit(targetCard.Suits);
                var count = 0;
                if (_card == null)
                {
                    (_card, count) = duplicateDrawCard(targetCard, _players[i]);
                }
                _tmpCards.Add(_card);

                if (count > 0)
                {
                    countCalculate.Add(_players[i].Name, count);
                }

                DisplayUno.DrawCard(_card, i * 2, topPosition);
                Console.ResetColor();
            }

            CalculateCardCount(countCalculate);
        }

        private (Card<RankUno, SuitUno>, int) duplicateDrawCard(Card<RankUno, SuitUno> targetCard, Player player)
        {
            var repeatedCount = 0;
            var _card = DrawCard();
            repeatedCount++;
            while (_card.Suits != targetCard.Suits)
            {
                repeatedCount++;
                player.UnoHand.AddUnoCard(_card);
                _card = DrawCard();
            }
            _card = player.UnoHand.GetCardBySuit(targetCard.Suits);
            return (_card, repeatedCount);
        }

        private Card<RankUno, SuitUno> GetTargetCard(int topPosition)
        {
            var targetCard = DrawCard();
            _tmpCards.Add(targetCard);
            topPosition += 1;
            DisplayUno.DrawCard(targetCard, 4, topPosition +1);

            Console.ResetColor();
            Console.WriteLine();
            return targetCard;
        }
        private void CalculateCardCount(Dictionary<string, int> countCalculate)
        {
            Console.WriteLine();
            foreach (var cal in countCalculate)
            {
                Console.WriteLine($"{cal.Key} 丟掉的卡片有 {cal.Value} 張");
            }

            var totalCount = 0;
            foreach (var player in _players)
            {
                Console.WriteLine($"{player.Name} 卡片有 {player.UnoHand.GetCardSize()} 張");
                totalCount += player.UnoHand.GetCardSize();
            }
            totalCount += _tmpCards.Count;
            var deckCardCount = _deck.GetCardSize();
            totalCount += deckCardCount;
            Console.WriteLine($"丟掉的卡片有 {_tmpCards.Count} 張");
            Console.WriteLine($"排堆的卡片有 {deckCardCount} 張");
            Console.WriteLine($"全部的卡片有 {totalCount} 張");
        }
        private Card<RankUno, SuitUno> DrawCard()
        {
            Card<RankUno, SuitUno> card = _deck.DrawCard();
            CheckIfDeckHasCard();
            return card;
        }

        private void CheckIfDeckHasCard()
        {
            if (_deck.GetCardSize() > 0)
            {
                return;
            }
            if (_tmpCards.Count > 0)
            {
                _deck.Shuffle(_tmpCards.ToArray());
                _tmpCards.Clear();
                Console.WriteLine();
                Console.WriteLine("卡片沒了，重新換卡");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("遊戲結束，沒牌了");

                var maxCardSize = _players.Max(p => p.UnoHand.GetCardSize());
                var losePlayers = _players.Where(p => p.UnoHand.GetCardSize() == maxCardSize)
                    .Select(p => p.Name)
                    .ToArray();
                var loser = string.Join(',', losePlayers);
                Console.WriteLine($"Loser: {loser}");
                Environment.Exit(0);
            }
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
