namespace _7.CommandPattern
{
    internal class ResetCommand : ICommand
    {
        private Telecom _telecom;
        private Dictionary<char, ICommand> _shortcut;
        private Dictionary<char, ICommand> _shortcutUndo;
        public ResetCommand(Dictionary<char, ICommand> shortcut)
        {
            _shortcut = shortcut;
            _shortcutUndo = shortcut;
        }
        public void Execute()
        {
            _shortcut.Clear();
        }

        public void Undo()
        {
            _shortcut = _shortcutUndo;
        }
    }
}
