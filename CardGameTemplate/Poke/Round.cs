using CardGame.Common;

namespace CardGame.Poke
{
    internal class Round
    {
        public Round(Player<Suit, Rank> player, Card<Suit, Rank> card)
        {
            Player = player;
            Card = card;
        }

        public Player<Suit, Rank> Player { get; set; }
        public Card<Suit, Rank> Card { get; set; }
    }
}
