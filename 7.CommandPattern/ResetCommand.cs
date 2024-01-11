namespace _7.CommandPattern
{
    internal class ResetCommand : ICommand
    {
        private List<Item>? _keyboard_shortcus;
        private List<Item>? _keyboard_shortcusUndo;

        public ResetCommand(List<Item> keyboard_shortcus)
        {
            _keyboard_shortcus = keyboard_shortcus;
        }
        public void Execute()
        {
            _keyboard_shortcusUndo = new List<Item>(_keyboard_shortcus);
            _keyboard_shortcus.Clear();
        }

        public void Undo()
        {
            _keyboard_shortcus = _keyboard_shortcusUndo;
        }
        public List<Item> GetKeyboardShortcus()
        {
            return _keyboard_shortcus;
        }
    }
}
