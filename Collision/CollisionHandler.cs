namespace _4.Collision
{
    internal abstract class CollisionHandler
    {

        protected List<Sprite> Lifes;
        protected CollisionHandler Next;
        public CollisionHandler(List<Sprite> lifes, CollisionHandler next) 
        {
            Next = next;
            Lifes = lifes;
        }

        public abstract void Handle(Sprite source, Sprite target);
    }
}
