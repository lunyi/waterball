using CardGame.Common;

namespace CardGame.Poke
{
    internal class Round
    {
        public Round(Player player, Card<Suit, Rank> card)
        {
            Player = player;
            Card = card;
        }

        public Player Player { get; set; }
        public Card<Suit, Rank> Card { get; set; }
    }
}
