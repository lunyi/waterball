using _8.StatePattern.States;

namespace _8.StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var character = new Character(1,1);
            character.EnterState(new NormalState(character));

            var monsters = new List<Monster>
            { 
                new Monster(5,6),
                new Monster(2,2),
                new Monster(8,7)
            };
            character.SetMonsters(monsters);

            var obstables = new List<Obstacle>
            {
                new Obstacle(1, 7),
                new Obstacle(3, 3)
            };

            var treasures = new List<Treasure>
            {
                new Treasure(2, 8),
                new Treasure(6, 3)
            };

            var game = new Game(character, monsters, obstables, treasures);
            game.Start();
        }
    }
}