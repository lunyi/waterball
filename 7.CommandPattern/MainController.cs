using System.Runtime.ExceptionServices;

namespace _7.CommandPattern
{
    internal class MainController
    {
        private Tank _tank = new Tank();
        private Telecom _telecom = new Telecom();
        private List<Item> selectItems;
        private List<Item> _keyboard_shortcut = new List<Item>();
        private Stack<ICommand> _executedCommands = new Stack<ICommand>();
        private Stack<ICommand> _redoCommands = new Stack<ICommand>();
        public MainController()
        {
            selectItems = new List<Item>
            {
                new Item('0', "MoveTankForward", new TankMoveForwardCommand(_tank)),
                new Item('1', "MoveTankBackward", new TankMoveForwardCommand(_tank)),
                new Item('2', "ConnectTelecom", new TelecomConnectCommand(_telecom)),
                new Item('3', "DisconnectTelecom", new TelecomDisconnectCommand(_telecom)),
                new Item('4', "ResetMainControlKeyboard", new ResetCommand(_keyboard_shortcut))
            };
        }
        public void Start()
        {
            while (true)
            {
                PrintQuestion();
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.KeyChar == '1')
                {
                    if (!SetupMacro())
                    {
                        Console.WriteLine();
                        continue;
                    }
                }
                else if (key.KeyChar == '2')
                {
                    Undo();
                }
                else if (key.KeyChar == '3')
                {
                    Redo();
                }
                else
                {
                    ExecuteCommand(key);
                }
            }
        }
        private void ExecuteCommand(ConsoleKeyInfo key)
        {
            try
            {
                var item = _keyboard_shortcut.FirstOrDefault(p => p.Key == key.KeyChar);
                var command = item?.Command;
                if (command != null)
                {
                    command.Execute();
                    _executedCommands.Push(command);
                }
                else
                {
                    Console.WriteLine("輸入錯誤，重來");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("輸入錯誤，重來");
            }
        }

        private void PrintQuestion()
        {
            Console.WriteLine();
            var ordered_shortcut = _keyboard_shortcut.OrderBy(p=>p.Key).ToList();
            foreach (var item in ordered_shortcut)
            {
                Console.WriteLine($"{item.Key}: {item.Description} ");
            }
            Console.Write("(1) 快捷鍵設置 (2) Undo (3) Redo (字母) 按下按鍵: ");
        }

        private char SetupCommand(bool ismacro)
        {
            Console.WriteLine();
            Console.Write($"Key: ");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (ismacro)
            {
                Console.WriteLine($"要將哪些指令設置成快捷鍵 {key.KeyChar} 的巨集（輸入多個數字，以空白隔開）: ");
            }
            else
            {
                Console.WriteLine($"要將哪一道指令設置到快捷鍵 {key.KeyChar} 上: ");
            }
            
            for (int i = 0; i < selectItems.Count; i++)
            {
                Console.WriteLine($"({selectItems[i].Key}) {selectItems[i].Description}");
            }
            return key.KeyChar;
        }

        private bool SetupMacro()
        {
            Console.Write("設置巨集指令(y / n): ");
            var yn = Console.ReadKey();
            try
            {
                var ismacro = yn.KeyChar.ToString().ToLower() == "y";
                var key = SetupCommand(ismacro);
                if (ismacro)
                {
                    var commandLine = Console.ReadLine();
                    var commandKeys = commandLine.Split(" ").Select(p => char.Parse(p)).ToList();
                    var items = selectItems.Where(p => commandKeys.Contains(p.Key)).ToList();
                    var description = string.Join(" & ", items.Select(p=>p.Description).ToArray());
                    var commands = items.Select(p => p.Command).ToList();
                    var macro = new Macro(key, description, commands);
                    _keyboard_shortcut.Add(new Item(key, description, macro));
                }
                else if (yn.KeyChar.ToString().ToLower() == "n")
                {
                    var commandKey = Console.ReadKey();
                    var selectedItem = selectItems.FirstOrDefault(p=>p.Key == commandKey.KeyChar);
                    var item = new Item(key, selectedItem.Description, selectedItem.Command);
                    _keyboard_shortcut.Add(item);
                }
                else
                {
                    return false;
                }

                for (int i = 0; i < _keyboard_shortcut.Count; i++)
                {
                    if (_keyboard_shortcut[i].Command is ResetCommand)
                    { 
                        var reset = _keyboard_shortcut[i].Command as ResetCommand;
                        List<Item> t1, t2;
                        (t1,t2) = reset.GetItems();
                    }
                } 
            }
            catch (Exception)
            { 
                Console.WriteLine("輸入錯誤，重來");
                return false;
            }
            return true;
        }

        private void Undo()
        {
            if (_executedCommands?.TryPop(out var redo) == true)
            {
                _redoCommands.Push(redo);
                redo?.Undo();
            }
        }

        private void Redo()
        {
            if (_redoCommands?.TryPop(out var redo) == true)
            {
                _executedCommands.Push(redo);
                redo?.Execute();
            }
        }
    }
}
