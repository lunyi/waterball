namespace _4.Collision
{
    internal class CollisionHeroWaterHandler : CollisionHandler
    {
        public CollisionHeroWaterHandler(List<Base> lifes, CollisionHandler next) : base(lifes, next)
        {
        }

        public override void Handle(Base start, Base end)
        {
            if (start.Key == 'W' && end.Key == 'H')
            {
                getHero(end);
                Lifes.Remove(start);
            }
            else if (start.Key == 'H' && end.Key == 'W')
            {
                var hero = getHero(start);
                hero.Index = end.Index;
                Lifes.Remove(end);
            }
            else
            {
                Next?.Handle(start, end);
            }
        }

        private Hero getHero(Base base_)
        {
            var hero = base_ as Hero;
            hero.Add_HP();
            return hero;
        }
    }
}
