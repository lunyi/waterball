namespace _4.Collision
{
    internal class CollisionSameLifeHandler : CollisionHandler
    {
        private static Dictionary<char, Func<int, Base>> map = new Dictionary<char, Func<int, Base>>()
            {
                { 'F',  i => new Base(i, 'F') },
                { 'W',  i => new Base(i, 'W') },
                { 'H',  i => new Hero(i) }
            };

        public CollisionSameLifeHandler(List<Base> lifes, CollisionHandler next) : base(lifes, next)
        {

        }

        public override void Handle(Base source, Base target)
        {
            if (target == null || target.Key == '\0')
            {
                Lifes.Add(map[source.Key](target.Index));
                Lifes.Remove(source);
            }
            else if (source.Key == target.Key)
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
}
