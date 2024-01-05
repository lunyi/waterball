namespace _4.Collision
{
    internal class Base
    {
        public int Index { get; set; }
        public virtual char Key { get; protected set; }

        public Base(int index)
        {
            Index = index;
        }
    }

    internal class Empty : Base
    {
        public Empty(int index) : base(index)
        {
        }
    }
}