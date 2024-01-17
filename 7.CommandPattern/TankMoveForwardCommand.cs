namespace _7.CommandPattern
{
    internal class TankMoveForwardCommand : ICommand
    {
        private Tank _tank;
        public TankMoveForwardCommand(Tank tank) 
        {
            _tank = tank;
        }
        public void Execute()
        {
            _tank.MoveForward();
        }

        public void Undo()
        {
            _tank.MoveBackward();
        }
    }
}
