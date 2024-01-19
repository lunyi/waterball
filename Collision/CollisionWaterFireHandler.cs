namespace _4.Collision
{
    internal class CollisionWaterFireHandler : CollisionHandler
    {
        public CollisionWaterFireHandler(List<Base> lifes, CollisionHandler next) : base(lifes, next)
        {
        }

        public override void Handle(Base start, Base end)
        {
            if ((start.Key == 'W' && end.Key == 'F') || (start.Key == 'F' && end.Key == 'W'))
            {
                Lifes.Remove(start);
                Lifes.Remove(end);
            }
            else
            {
                Next?.Handle(start, end);
            }
        }
    }
}
