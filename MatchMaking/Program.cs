using System.Linq;

namespace MatchMaking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var idv1 = new Individual(1, "Hank", Gender.Male, 20, "hi, my name is Hank", "badminton", new Coord(120.18, 23.05));
            var idv2 = new Individual(2, "Bob", Gender.Male, 21, "hi, my name is Bob", "budda,gym", new Coord(120.98, 23.90));
            var idv3 = new Individual(3, "Charlie", Gender.Male, 22, "hi, my name is Charlie", "badminton,backetball", new Coord(120.45, 23.80));
            var idv4 = new Individual(4, "Frank", Gender.Male, 23, "hi, my name is Frank", "badminton,baseball", new Coord(120.67, 23.72));
            var idv5 = new Individual(5, "Henry", Gender.Male, 24, "hi, my name is Henry", "valleyball", new Coord(120.88, 23.67));
            var idv6 = new Individual(6, "Eva", Gender.Female, 20, "hi, my name is Eva", "sport,piano", new Coord(120.58, 23.55));
            var idv7 = new Individual(7, "Katherine", Gender.Female, 21, "hi, my name is Katherine", "ukelele", new Coord(120.23, 23.46));
            var idv8 = new Individual(8, "Mia", Gender.Female, 22, "hi, my name is Mia", "sport", new Coord(120.01, 23.31));
            var idv9 = new Individual(9, "Sophie", Gender.Female, 23, "hi, my name is Sophie", "jogging,sport", new Coord(120.17, 23.27));
            var idv10 = new Individual(10, "Grace", Gender.Female, 24, "hi, my name is Grace", "piano,valleyball", new Coord(120.36, 23.15));

            var indviduals = new[] {
                idv1, idv2, idv3, idv4, idv5, idv6, idv7, idv8, idv9, idv10
            };

            var matchMaking = new MatchMaking(indviduals);
            matchMaking.SetMatchMethod(new DistanceBaseStrategy());
            //matchMaking.SetMatchMethod(new Reverse(new MatchDistanceBased()));

            var res1 = matchMaking.Match<double>(idv1, dict => dict.OrderBy(p => p.Value));
            var res2 = matchMaking.Match<double>(idv1, dict => dict.OrderByDescending(p => p.Value));

            matchMaking.SetMatchMethod(new HabitsBaseStrategy());
            //matchMaking.SetMatchMethod(new Reverse(new MatchHabitsBased()));

            var res3 = matchMaking.Match<int>(idv1, dict => dict.OrderBy(p => p.Value));
            var res4 = matchMaking.Match<int>(idv1, dict => dict.OrderByDescending(p => p.Value));

            foreach (var item in res1)
            {
                Console.WriteLine($"{item.Name}");
            }

            Console.WriteLine("=========");

            foreach (var item in res2)
            {
                Console.WriteLine($"{item.Name}");
            }

            Console.WriteLine("=========");

            foreach (var item in res3)
            {
                Console.WriteLine($"{item.Name}");
            }

            Console.WriteLine("=========");

            foreach (var item in res4)
            {
                Console.WriteLine($"{item.Name}");
            }

            Console.ReadKey();
        }
    }
}
