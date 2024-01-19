namespace _4.Collision
{
    internal abstract class CollisionHandler
    {

        protected List<Base> Lifes;
        protected CollisionHandler Next;
        public CollisionHandler(List<Base> lifes, CollisionHandler next) 
        {
            Next = next;
            Lifes = lifes;
        }

        public abstract void Handle(Base source, Base target);
    }
}
