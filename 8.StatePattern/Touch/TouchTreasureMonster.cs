namespace _8.StatePattern.Touch.Touch
{
    internal class TouchTreasureMonster : Touches
    {
        private List<Monster> _monsters;
        private List<Treasure> _treasure;

        public TouchTreasureMonster(List<Monster> monsters, List<Treasure> treasure)
        {
            _monsters = monsters;
            _treasure = treasure;
        }

        public void CheckIfTouch()
        {

        }
    }
}
