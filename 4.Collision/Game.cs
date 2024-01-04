namespace _4.Collision
{
    internal class Game
    {
        Random random = new Random();
        List<Base> Lifes;
        private const int total_count = 30;
        private const int life_count = 10;
        private const int interval = 3;

        private Dictionary<char, Func<int, Base>> map = new Dictionary<char, Func<int, Base>>()
            {
                { 'F',  i => new Fire(i) },
                { 'W',  i => new Water(i) },
                { 'H',  i => new Hero(i) }
            };

        internal Game()
        {
            Lifes = GenerateLifes();
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

                    var start = Lifes.First(p=>p.Index == source);
                    var end = getTarget(target);

                    if (end == null)
                    {
                        Lifes.Add(map[start.Key](target));
                        Lifes.Remove(start);
                    }
                    else 
                    {
                        collision(start, end);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"輸入有錯，請重新輸入！{ex.Message}");
                }
                finally { Console.Clear(); }
            }
        }

        private void collision(Base start, Base end)
        {
            if (start.Key == end.Key)
            {
                Console.WriteLine("移動失敗");
                Thread.Sleep(1000);
            }
            else if (start.Key == 'W' && end.Key == 'F')
            {
                Lifes.Remove(start);
                Lifes.Remove(end);
            }
            else if (start.Key == 'F' && end.Key == 'W')
            {
                Lifes.Remove(start);
                Lifes.Remove(end);
            }
            else if (start.Key == 'H' && end.Key == 'F')
            {
                var hero = start as Hero;
                hero.Deduct_HP();
                hero.Index = end.Index;
                Lifes.Remove(end);
            }
            else if (start.Key == 'F' && end.Key == 'H')
            {
                var hero = end as Hero;
                hero.Deduct_HP();
                hero.Index = start.Index;
                Lifes.Remove(start);
            }
            else if (start.Key == 'W' && end.Key == 'H')
            {
                var hero = end as Hero;
                hero.Add_HP();
                hero.Index = start.Index;
                Lifes.Remove(start);
            } 
            else if (start.Key == 'H' && end.Key == 'W')
            {
                var hero = start as Hero;
                hero.Add_HP();
                hero.Index = end.Index;
                Lifes.Remove(end);
            }
        }

        private Base? getTarget(int target)
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
        }
        private List<int> GenerateRandomNumbers(int minValue, int maxValue, int count)
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

        private List<Base> GenerateLifes()
        {
            var numberList = GenerateRandomNumbers(0, total_count-1, life_count)
                .OrderBy(p => p).ToList();
            var targetLife = new char[] { 'W', 'F', 'H' };



            var lifes = new List<Base>();
            foreach (var item in numberList)
            {
                var key = targetLife[random.Next(0, targetLife.Length)];
                lifes.Add(map[key](item));
            }
            return lifes;
        }
    }
}
