namespace TreasureMapGame
{
    public class Monster
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private int prevX, prevY;

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveTowardsPlayer(int playerX, int playerY, int mapWidth, int mapHeight)
        {
            prevX = X;
            prevY = Y;

            if (X < playerX) X++;
            else if (X > playerX) X--;

            if (Y < playerY) Y++;
            else if (Y > playerY) Y--;
        }

        public void UndoMove()
        {
            X = prevX;
            Y = prevY;
        }
    }
}
