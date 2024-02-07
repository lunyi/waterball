namespace _4.Collision
{
    internal class CollisionSameLifeHandler : CollisionHandler
    {
        private static Dictionary<char, Func<int, Sprite>> map = new Dictionary<char, Func<int, Sprite>>()
            {
                { 'F',  i => new Sprite(i, 'F') },
                { 'W',  i => new Sprite(i, 'W') },
                { 'H',  i => new Hero(i) }
            };

        public CollisionSameLifeHandler(List<Sprite> lifes, CollisionHandler next) : base(lifes, next)
        {

        }

        public override void Handle(Sprite start, Sprite end)
        {
            if (end == null || end.Key == '\0')
            {
                Lifes.Add(map[start.Key](end.Index));
                Lifes.Remove(start);
            }
            else if (start.Key == end.Key)
            {
                Console.WriteLine("移動失敗");
                Thread.Sleep(1000);
            }
            else
            {
                Next?.Handle(start, end);
            }
        }
    }
}
