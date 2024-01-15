using _8.StatePattern.States;

namespace _8.StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var character = new Character();
            character.EnterState(new NormalState(character));

            var monsters = new List<Monster>
            { 
                new Monster(5,6),
                new Monster(2,2),
                new Monster(4,7)
            };
            var game = new Game(character, monsters);
            game.Start();
        }
    }
}