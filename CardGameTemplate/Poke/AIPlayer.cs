﻿using CardGame.Common;

namespace CardGame.Poke
{
    internal class AIPlayer: Player<Suit, Rank>
    {
        private ExchangeHands? ExchangeHands = null;
        public AIPlayer(int index) : base(index) 
        { 
        
        }

        public override void Naming() 
        { 
            Name = $"AI Player-{Index}";
        }

        public override Card<Suit, Rank> SelectCard()
        {
            if (ExchangeHands == null)
            {
                var ifexhange = random.Next(0, 3);
                if (ifexhange == 0)
                {
                    var exchangees = Game.GetPlayers()
                        .Where(p => p.ExchangeHands == null && p.Index != Index)
                        .ToArray();

                    ExchangeHands = new ExchangeHands(this, exchangees[random.Next(0, exchangees.Count())]);
                }
            }
            else
            {
                ExchangeHands.CountDown();
            }

            return Hand.SelectCard(Hand.Size());
        }

        public override Card<Suit, Rank> SelectCard(Suit suit)
        {
            throw new NotImplementedException();
        }
    }
}
