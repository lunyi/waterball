using CardGame.Common;

namespace CardGame.Showdown
{
    internal abstract class Player : Player<Card>
    {
        protected Player(int index) : base(index)
        {
        }

        public abstract Card SelectCard();
        public int AddPoint()
        {
            return Point++;
        }

        public int GetPoint()
        {
            return Point;
        }
    }

    internal static class PlayerExtensions
    {
        public static (string[], int) GetFinalWinner(this Player[]? players)
        {
            var point = players.Max(player => player.GetPoint());
            var playerNames = players.Where(p => p.GetPoint() == point)
                .Select(p => p.Name)
                .ToArray();
            return (playerNames, point);
        }
    }
}
