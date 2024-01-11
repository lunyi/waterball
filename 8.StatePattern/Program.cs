namespace _8.StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                var test = key.KeyChar;
                Console.WriteLine(test);
            }
        }
    }
}