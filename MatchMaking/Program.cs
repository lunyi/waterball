using System.Linq;

namespace MatchMaking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var idv1 = new Individual(1, "Hank", Gender.Male, 20, "hi, my name is Hank", "badminton", 120.18, 23.05);
            var idv2 = new Individual(2, "Bob", Gender.Male, 21, "hi, my name is Bob", "budda,gym", 120.98, 23.90);
            var idv3 = new Individual(3, "Charlie", Gender.Male, 22, "hi, my name is Charlie", "badminton,backetball", 120.45, 23.80);
            var idv4 = new Individual(4, "Frank", Gender.Male, 23, "hi, my name is Frank", "badminton,baseball", 120.67, 23.72);
            var idv5 = new Individual(5, "Henry", Gender.Male, 24, "hi, my name is Henry", "valleyball", 120.88, 23.67);
            var idv6 = new Individual(6, "Eva", Gender.Female, 20, "hi, my name is Eva", "sport,piano", 120.58, 23.55);
            var idv7 = new Individual(7, "Katherine", Gender.Female, 21, "hi, my name is Katherine", "ukelele", 120.23, 23.46);
            var idv8 = new Individual(8, "Mia", Gender.Female, 22, "hi, my name is Mia", "sport", 120.01, 23.31);
            var idv9 = new Individual(9, "Sophie", Gender.Female, 23, "hi, my name is Sophie", "jogging,sport", 120.17, 23.27);
            var idv10 = new Individual(10, "Grace", Gender.Female, 24, "hi, my name is Grace", "piano,valleyball", 120.36, 23.15);

            var indviduals = new[] {
                idv1, idv2, idv3, idv4, idv5, idv6, idv7, idv8, idv9, idv10
            };

            var matchMaking = new MatchMaking(indviduals);
            matchMaking.SetMatchMethod(new MatchDistanceBased());

            var res1 = matchMaking.Match<double>(idv1, dict => dict.OrderBy(p => p.Value));
            var res2 = matchMaking.Match<double>(idv1, dict => dict.OrderByDescending(p => p.Value));

            matchMaking.SetMatchMethod(new MatchHabitsBased());

            var res3 = matchMaking.Match<int>(idv1, dict => dict.OrderBy(p => p.Value));
            var res4 = matchMaking.Match<int>(idv1, dict => dict.OrderByDescending(p => p.Value));

            for (int i = 0; i < res1.Length; i++)
            {
                Console.WriteLine($"{res1[i].Name}");
            }

            Console.WriteLine("=========");

            for (int i = 0; i < res2.Length; i++)
            {
                Console.WriteLine($"{res2[i].Name}");
            }

            Console.WriteLine("=========");

            for (int i = 0; i < res3.Length; i++)
            {
                Console.WriteLine($"{res3[i].Name}");
            }

            Console.WriteLine("=========");

            for (int i = 0; i < res4.Length; i++)
            {
                Console.WriteLine($"{res4[i].Name}");
            }

            Console.ReadKey();
        }
    }
}
