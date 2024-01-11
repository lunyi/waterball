namespace _7.CommandPattern
{
    internal class MacroCommand : ICommand
    {
        private List<ICommand> _commands;
        public string Description { get; set; }
        public char Key { get; set; }

        public MacroCommand(char key, string description, List<ICommand> commands) 
        {
            Key = key;
            Description = description;
            _commands = commands;
        }

        public void Execute()
        {
            for (int i = 0; i < _commands.Count; i++) 
            {
                _commands[i].Execute();
            }    
        }

        public void Undo()
        {
            for (int i = 0; i < _commands.Count; i++)
            {
                _commands[i].Undo();
            }
        }
    }
}
