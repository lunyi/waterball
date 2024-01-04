namespace _4.Collision
{
    internal class Base
    {
        public int Index { get; private set; }

        public Base(int index)
        {
            Index = index;
        }

        public virtual Char GetKey()
        {
            return '0';
        }
    }
}