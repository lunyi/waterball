namespace _7.CommandPattern
{
    internal class ResetCommand : ICommand
    {
        private List<Item> _items;
        private List<Item> _itemsUndo;
        private Item[] _itemssArray = new Item[0] ;
        public ResetCommand(List<Item> items)
        {
            _items = items;
            _itemsUndo = items;
        }
        public void Execute()
        {
            _items.CopyTo(_itemssArray);
            _items.Clear();
        }

        public void Undo()
        {
            _items = _itemssArray.ToList();
        }

        public (List<Item>, List<Item>) GetItems()
        {
            return (_items, _itemsUndo);
        }
    }
}
