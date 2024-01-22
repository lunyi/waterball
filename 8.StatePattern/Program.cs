using _8.StatePattern.States;

namespace _8.StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var monsters = new List<Monster>
            {
                new Monster(15,6),
                new Monster(2,12),
                new Monster(18,7)
            };         

            var obstables = new List<Obstacle>
            {
                new Obstacle(11, 7),
                new Obstacle(3, 13)
            };

            var treasures = new List<Treasure>
            {
                new Treasure(12, 8),
                new Treasure(6, 13)
            };

            var character = new Character(1,1);
            character.EnterState(new NormalState());
            character.SetMonsters(monsters);
            character.SetObstacles(obstables);
            
            var treasureGenerator = new TreasureGenerator();
            var game = new Game(character, monsters, obstables, treasures, new Touch(treasureGenerator));
            game.Start();
        }
    }
}