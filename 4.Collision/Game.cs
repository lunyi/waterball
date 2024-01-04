using System;

namespace _4.Collision
{
    internal class Game
    {
        Random random = new Random();
        Dictionary<int, Base> Lifes;
        private int total_count = 30;
        private int life_count = 10;

        internal Game()
        {
            Lifes = GenerateLifes();
        }

        internal void Init()
        {
            setup();
        }

        private Dictionary<int, Base> GenerateLifes()
        {
            var numberList = GenerateRandomNumbers(1, total_count, life_count)
                .OrderBy(p => p).ToList();
            var targetLife = new char[] { 'W', 'F', 'H' };

            var map = new Dictionary<char, Func<int, Base>>()
            {
                { 'F',  i => new Fire(i) },
                { 'W',  i => new Water(i) },
                { 'H',  i => new Hero(i) }
            };

            var lifes = new Dictionary<int, Base>();
            foreach (var item in numberList)
            {
                var key = targetLife[random.Next(0, targetLife.Length)];
                lifes.Add(item, map[key](item));
            }
            return lifes;
        }
        private void setup() 
        {
            for (int i = 1; i <= total_count; i++)
            {
                var iswrite = false;
                Console.SetCursorPosition(i * 3, 0);
                foreach (var item in Lifes)
                {
                    if (item.Key == item.Value.Index)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(item.Value.GetKey());
                        Console.ResetColor();
                        iswrite = true;
                    }
                }
            }

            for (int i = 1; i <= 30; i++)
            {
                Console.SetCursorPosition(i * 3, 1);
                Console.Write(i);
            }

            Console.ReadKey();
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
    }
}
