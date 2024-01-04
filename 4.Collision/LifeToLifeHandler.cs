﻿namespace _4.Collision
{
    internal abstract class LifeToLifeHandler
    {

        protected List<Base> Lifes;
        protected LifeToLifeHandler Next;
        public LifeToLifeHandler(List<Base> lifes, LifeToLifeHandler next) 
        {
            Next = next;
            Lifes = lifes;
        }

        public abstract void Handle(Base source, Base target);
    }

    internal class EndIsNullHandler : LifeToLifeHandler
    {
        private static Dictionary<char, Func<int, Base>> map = new Dictionary<char, Func<int, Base>>()
            {
                { 'F',  i => new Fire(i) },
                { 'W',  i => new Water(i) },
                { 'H',  i => new Hero(i) }
            };
        public EndIsNullHandler(List<Base> lifes, LifeToLifeHandler next) : base(lifes, next)
        {

        }

        public override void Handle(Base start, Base end)
        {
            if (end.Key == '\0')
            {
                Lifes.Add(map[start.Key](end.Index));
                Lifes.Remove(start);
            }
            else
            {
                Next?.Handle(start, end);
            }
        }
    }

    internal class SameLifeHandler : LifeToLifeHandler
    {
        public SameLifeHandler(List<Base> lifes, LifeToLifeHandler next) : base(lifes, next)
        {

        }

        public override void Handle(Base source, Base target)
        {
            if (source.Key == target.Key)
            {
                Console.WriteLine("移動失敗");
                Thread.Sleep(1000);
            }
            else
            {
                Next?.Handle(source, target);
            }
        }
    }
    internal class WaterFireHandler : LifeToLifeHandler
    {
        public WaterFireHandler(List<Base> lifes, LifeToLifeHandler next) : base(lifes, next)
        {
        }

        public override void Handle(Base start, Base end)
        {
            if (start.Key == 'W' && end.Key == 'F')
            {
                Lifes.Remove(start);
                Lifes.Remove(end);
            }
            else if (start.Key == 'F' && end.Key == 'W')
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

    internal class HeroFireHandler : LifeToLifeHandler
    {
        public HeroFireHandler(List<Base> lifes, LifeToLifeHandler next) : base(lifes, next)
        {
        }

        public override void Handle(Base start, Base end)
        {
            if (start.Key == 'H' && end.Key == 'F')
            {
                var hero = start as Hero;
                hero.Deduct_HP();
                hero.Index = end.Index;
                if (hero.Get_HP()<=0)
                {
                    Lifes.Remove(start);
                }
                Lifes.Remove(end);
            }
            else if (start.Key == 'F' && end.Key == 'H')
            {
                var hero = end as Hero;
                hero.Deduct_HP();

                if (hero.Get_HP() <= 0)
                {
                    Lifes.Remove(end);
                }

                Lifes.Remove(start);
            }
            else
            {
                Next?.Handle(start, end);
            }
        }
    }
    internal class HeroWaterHandler : LifeToLifeHandler
    {
        public HeroWaterHandler(List<Base> lifes, LifeToLifeHandler next) : base(lifes, next)
        {
        }

        public override void Handle(Base start, Base end)
        {
            if (start.Key == 'W' && end.Key == 'H')
            {
                var hero = end as Hero;
                hero.Add_HP();
                Lifes.Remove(start);
            }
            else if (start.Key == 'H' && end.Key == 'W')
            {
                var hero = start as Hero;
                hero.Add_HP();
                hero.Index = end.Index;
                Lifes.Remove(end);
            }
            else
            {
                Next?.Handle(start, end);
            }
        }
    }
}
