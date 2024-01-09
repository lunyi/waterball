namespace _7.CommandPattern
{
    internal class Item
    {
        public Item(char key, string description, ICommand command)
        {
            Key = key;
            Description = description;
            Command = command;
        }

        public char Key { get; set; }
        public string Description { get; set; }
        public ICommand Command { get; set; }
    }

    internal static class ItemExtensions
    { 
        public static ICommand GetCommandByKey(this List<Item> list, char key)
        {
            return list.First(p => p.Key == key).Command;
        }
    }
}
