﻿using System.Numerics;

namespace _3.UnoGame
{
    internal class UnoGame
    {
        private int CardCount = 5;
        private List<Card> _tmpCards = new List<Card>();

        private IDeck _deck;
        private Player[] _players;

        public UnoGame(IDeck deck, Player[] players)
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

                countCalculate.Clear();
                checkIfFinal();
            }

            Console.ReadKey();
        }

        private void RunEachRound(Dictionary<string, int> countCalculate)
        {
            var topPosition = DisplayUno.DisplayCardsOfPlayers(_players);
            var targetCard = GetTargetCard(topPosition);
            DisplayUno.DisplayAllCards(_deck.GetAllCards());

            topPosition++;

            for (int i = 0; i < _players.Length; i++)
            {
                Console.Write($" {_players[i].Name}    ");
            }
            topPosition += 8;
            for (int i = 0; i < _players.Length; i++)
            {
                var _card = _players[i].Hand.SelectCard(targetCard.Suit);
                var count = 0;
                if (_card == null)
                {
                    (_card, count) = repeatedDrawCard(targetCard, _players[i]);
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
            Console.ReadKey();
        }

        private (Card, int) repeatedDrawCard(Card targetCard, Player player)
        {
            var repeatedCount = 0;
            var _card = DrawCard();
            repeatedCount++;
            while (_card.Suit != targetCard.Suit)
            {
                repeatedCount++;
                player.AddHandCard(_card);
                _card = DrawCard();
            }
            return (_card, repeatedCount);
        }

        private Card GetTargetCard(int topPosition)
        {
            var targetCard = DrawCard();
            _tmpCards.Add(targetCard);
            topPosition += 1;
            
            DisplayUno.DrawCard(targetCard, 4, topPosition + 1);

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
                Console.WriteLine($"{player.Name} 卡片有 {player.Hand.Size()} 張");
                totalCount += player.Hand.Size();
            }
            totalCount += _tmpCards.Count;
            var deckCardCount = _deck.Size();
            totalCount += deckCardCount;
            Console.WriteLine($"丟掉的卡片有 {_tmpCards.Count} 張");
            Console.WriteLine($"排堆的卡片有 {deckCardCount} 張");
            Console.WriteLine($"全部的卡片有 {totalCount} 張");
        }
        private Card DrawCard()
        {
            Card card = _deck.DrawCard();
            if (card == null)
            {
                var s = "";
                var cards = _deck.GetAllCards();
            }
            CheckIfDeckHasCard();
            return card;
        }

        private void CheckIfDeckHasCard()
        {
            if (_deck.Size() > 0)
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

                var maxCardSize = _players.Max(p => p.Hand.Size());
                var losePlayers = _players.Where(p => p.Hand.Size() == maxCardSize)
                    .Select(p => p.Name)
                    .ToArray();
                var loser = string.Join(',', losePlayers);
                Console.WriteLine($"Loser: {loser}");
                Environment.Exit(0);
            }
        }
        private void checkIfFinal()
        {
            if (_players.Any(p => p.Hand.Size() > 0))
            {
                return;
            }

            Console.WriteLine("Game Over");
            var players = _players
                .Where(p => p.Hand.Size() == 0)
                .Select(p => p.Name).ToArray();

            Console.WriteLine("The winners is ");

            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($" {players[i]} ");
            }
        }
        private void initPlayerCards()
        {
            _deck.Shuffle();

            foreach (var player in _players)
            {
                player.Naming();
                player.Hand = new Hand();

                for (int i = 0; i < CardCount; i++)
                {
                    player.Hand.AddHandCard(_deck.DrawCard());
                }
            }
        }
    }
}
