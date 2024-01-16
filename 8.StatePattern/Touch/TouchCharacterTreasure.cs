namespace _8.StatePattern.Touch.Touch
{
    internal class TouchCharacterTreasure : Touches
    {
        private Character _character;
        private List<Monster> _monsters;

        public TouchCharacterTreasure(Character character, List<Monster> monsters)
        {
            _character = character;
            _monsters = monsters;
        }

        public void CheckIfTouch()
        {
            for (int i = 0; i < _monsters.Count; i++)
            {
                if (_monsters[i]._x == _character.X && _monsters[i]._y == _character.Y)
                {
                    _character.HP -= 50;
                    //Console.WriteLine("與monster碰撞");
                    _monsters.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
