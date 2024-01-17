namespace _7.CommandPattern
{
    internal interface ICommand
    {
        void Execute();
        void Undo();
    }
}
