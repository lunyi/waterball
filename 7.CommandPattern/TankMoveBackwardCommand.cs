namespace _7.CommandPattern
{
    internal class TankMoveBackwardCommand : ICommand
    {
        private Tank _tank;
        public TankMoveBackwardCommand(Tank tank) 
        {
            _tank = tank;
        }
        public void Execute()
        {
            _tank.MoveBackward();
        }

        public void Undo()
        {
            _tank.MoveForward();
        }
    }
}
