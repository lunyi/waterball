namespace _4.Collision
{
    internal class Sprite
    {
        public int Index { get; set; }
        public virtual char Key { get; protected set; }

        public Sprite(int index)
        {
            Index = index;
        }

        public Sprite(int index, char key)
        {
            Index = index;
            Key = key;
        }
    }
}