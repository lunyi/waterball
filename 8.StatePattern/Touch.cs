namespace _8.StatePattern
{
    internal class Touch
    {
        public void CheckIfTouchCharacterAndObstacles(Character character, List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].X == character.X && obstacles[i].Y == character.Y)
                {
                    //Console.WriteLine("與monster碰撞");
                    //obstacles[i].Clear();
                    obstacles.Remove(obstacles[i]);
                    break;
                }
            }
        }

        public void CheckIfTouchCharacterAndMonsters(Character character, List<Monster> _monsters)
        {
            for (int i = 0; i < _monsters.Count; i++)
            {
                if (_monsters[i].X == character.X && _monsters[i].Y == character.Y)
                {
                    character.HP -= 50;
                    //Console.WriteLine("與monster碰撞");
                    _monsters[i].Clear();
                    _monsters.Remove(_monsters[i]);
                    break;
                }
            }
        }
        public void CheckIfTouchCharacterAndTreasures(Character character, List<Treasure> treasures)
        {
            for (int i = 0; i < treasures.Count; i++)
            {
                if (treasures[i].X == character.X && treasures[i].Y == character.Y)
                {
                    //Console.WriteLine("與monster碰撞");
                    treasures.RemoveAt(i);
                    break;
                }
            }
        }

        public void CheckIfTouchTreasuresAndMonsters(List<Monster> monsters, List<Treasure> treasures)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                for (int j = 0; j < treasures.Count; j++)
                {
                    if (monsters[i].X == treasures[j].X && monsters[i].Y == treasures[j].Y)
                    {
                        //var treasure = new
                    }
                }
            }
        }
    }
}
