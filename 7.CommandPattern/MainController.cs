namespace _7.CommandPattern
{
    internal class MainController
    {
        private Tank _tank = new Tank();
        private Telecom _telecom = new Telecom();
        private List<Item> selectItems;
        private static List<Item> _keyboard_shortcut = new List<Item>();
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

                switch (key.KeyChar)
                {
                    case '1':
                        SetupMacro();
                        break;
                    case '2':
                        Undo();
                        break;
                    case '3':
                        Redo();
                        break;
                    default:
                        ExecuteCommand(key);
                        break;
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
                Console.WriteLine("執行錯誤，重來");
            }
        }

        private void PrintQuestion()
        {
            Console.WriteLine();

            if (_keyboard_shortcut.Any(p => p == null))
            {
                _keyboard_shortcut = _keyboard_shortcut.Where(p => p != null).ToList();
            }

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

        private void InsertShortCutByMacro(char key)
        {
            var commandLine = Console.ReadLine();
            var commandKeys = commandLine.Split(" ").Select(p => char.Parse(p)).ToList();
            var items = selectItems.Where(p => commandKeys.Contains(p.Key)).ToList();
            var description = string.Join(" & ", items.Select(p => p.Description).ToArray());
            var commands = items.Select(p => p.Command).ToList();
            var macro = new MacroCommand(key, description, commands);
            _keyboard_shortcut.Add(new Item(key, description, macro));
        }

        private void InsertShortCutByKey(char key)
        {
            try
            {
                var commandKey = Console.ReadKey();
                var selectedItem = selectItems.FirstOrDefault(p => p.Key == commandKey.KeyChar);
                var item = new Item(key, selectedItem.Description, selectedItem.Command);
                _keyboard_shortcut.Add(item);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString()); 
            }
        }

        private bool SetupMacro()
        {
            Console.Write("設置巨集指令(y / n): ");
            var keyYn = Console.ReadKey().KeyChar.ToString().ToLower();
            if (!(keyYn == "y" || keyYn == "n"))
            {
                Console.WriteLine("輸入錯誤，重來");
                return false;
            }
            var ismacro = keyYn == "y";
            var key = SetupCommand(ismacro);
            if (ismacro)
            {
                InsertShortCutByMacro(key);
            }
            else if (keyYn == "n")
            {
                InsertShortCutByKey(key);
            }
            else
            {
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

                if (redo is ResetCommand)
                {
                    var reset1 = redo as ResetCommand;
                    _keyboard_shortcut = reset1.GetKeyboardShortcus();
                }
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
