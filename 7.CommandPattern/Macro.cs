namespace _7.CommandPattern
{
    internal class Macro : ICommand
    {
        private List<Item> _items;
        public string Description { get; set; }
        public char Key { get; set; }

        public Macro(List<Item> items) 
        {
            _items = items;
        }

        public void Execute()
        {
            var list = _items.Select(p => p.Command).ToList();
            for (int i = 0; i < list.Count; i++) 
            {
                list[i].Execute();
            }    
        }

        public void Undo()
        {
            var list = _items.Select(p => p.Command).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Undo();
            }
        }

        public string GetDescription()
        {
            var list = _items.Select(p => p.Description).ToList();
            return string.Join(" & ", list);
        }
    }
}
