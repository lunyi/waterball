namespace _4.Collision
{
   
    internal class CollisionHeroFireHandler : CollisionHandler
    {
        public CollisionHeroFireHandler(List<Base> lifes, CollisionHandler next) : base(lifes, next)
        {
        }

        public override void Handle(Base start, Base end)
        {
            if (start.Key == 'H' && end.Key == 'F')
            {
                var hero = getHero(start);
                hero.Index = end.Index;
                Lifes.Remove(end);
            }
            else if (start.Key == 'F' && end.Key == 'H')
            {
                getHero(end);
                Lifes.Remove(start);
            }
            else
            {
                Next?.Handle(start, end);
            }
        }
        private Hero getHero(Base base_)
        {
            var hero = base_ as Hero;
            hero.Deduct_HP();

            if (hero.Get_HP() <= 0)
            {
                Lifes.Remove(base_);
            }
            return hero;
        }
    }
}
