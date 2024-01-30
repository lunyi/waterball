using CardGame.Common;

namespace CardGame.Showdown
{
    internal class Round
    {
        public Round(Player player, Card card)
        {
            Player = player;
            Card = card;
        }

        public Player Player { get; set; }
        public Card Card { get; set; }
    }
}
