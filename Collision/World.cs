namespace _4.Collision
{
    internal class World
    {
        Random random = new Random();
        List<Sprite> Lifes;
        private const int total_count = 30;
        private const int life_count = 10;
        private const int interval = 3;

        private Dictionary<char, Func<int, Sprite>> map = new Dictionary<char, Func<int, Sprite>>()
            {
                { 'F',  i => new Sprite(i, 'F') },
                { 'W',  i => new Sprite(i, 'W') },
                { 'H',  i => new Hero(i) }
            };

        internal World()
        {
            Lifes = generateLifes();
        }

        internal void Init()
        {
            while (true)
            {
                display();
                
                Console.WriteLine("請輸入兩數字, 中間用空白做間隔");
                var input = Console.ReadLine();

                try
                {
                    var inputs = input.Split(' ');
                    var source = Convert.ToInt32(inputs[0]);
                    var target = Convert.ToInt32(inputs[1]);
                    if (!validate(source, target))
                    {
                        continue;
                    }

                    var start = getStarter(source);
                    var end = getEnder(target);
                    move(start, end);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"輸入有錯，請重新輸入！{ex.Message}");
                }
                finally { Console.Clear(); }
            }
        }

        private void move(Sprite start, Sprite end)
        {
            var hander =  new CollisionSameLifeHandler(Lifes, new CollisionWaterFireHandler(Lifes, new CollisionHeroFireHandler(Lifes, new CollisionHeroWaterHandler(Lifes, null))));
            hander.Handle(start, end);
        }

        private Sprite? getStarter(int index)
        {
            return Lifes.First(p => p.Index == index);
        }
        private Sprite? getEnder(int target)
        {
            if (!Lifes.Any(p => p.Index == target))
            {
                return null;
            }
            return Lifes.First(p=>p.Index == target);
        }
        private bool validate(int source, int target)
        {
            if (source.Equals(target))
            {
                Console.WriteLine($"輸入資料相同，請重新輸入！");
                Thread.Sleep(1000);
                return false;
            }

            if (!Lifes.Any(p => p.Index == source))
            {
                Console.WriteLine($"輸入資料沒有life，請重新輸入！");
                Thread.Sleep(1000);
                return false;
            }
            return true;
        }
        private void display() 
        {
            for (int i = 0; i < total_count; i++)
            {
                var iswrite = false;
                Console.SetCursorPosition(i * interval, 0);
                foreach (var item in Lifes)
                {
                    if (i == item.Index)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(item.Key);
                        Console.ResetColor();
                        iswrite = true;
                    }
                }
                if (!iswrite)
                {
                    Console.Write(" ");
                }
            }

            for (int i = 0; i < total_count; i++)
            {
                Console.SetCursorPosition(i * interval, 1);
                Console.Write(i);
            }

            Console.WriteLine();
            Console.WriteLine();

            List<Hero?> heros = Lifes.Where(p=>p is Hero)
                .Select(p=>p as Hero).ToList();

            for (int i = 0;i < heros.Count;i++) 
            {
                Console.WriteLine($"hero: {heros[i].Index}, HP:{heros[i].Get_HP()}");
            }

            Console.WriteLine();
        }
        private List<int> generateRandomNumbers(int minValue, int maxValue, int count)
        {
            if (count > maxValue - minValue + 1 || count < 0)
            {
                throw new ArgumentException("無法生成指定數量的不重複隨機數字。");
            }

            HashSet<int> numbers = new HashSet<int>();

            while (numbers.Count < count)
            {
                int randomNumber = random.Next(minValue, maxValue + 1);
                numbers.Add(randomNumber);
            }

            return numbers.ToList();
        }

        private List<Sprite> generateLifes()
        {
            var numberList = generateRandomNumbers(0, total_count-1, life_count)
                .OrderBy(p => p).ToList();
            var targetLife = new char[] { 'W', 'F', 'H' };

            var lifes = new List<Sprite>();
            foreach (var item in numberList)
            {
                var key = targetLife[random.Next(0, targetLife.Length)];
                lifes.Add(map[key](item));
            }
            return lifes;
        }
    }
}
