namespace _7.CommandPattern
{
    internal class MainController
    {
        private Tank _tank = new Tank();
        private Telecom _telecom = new Telecom();
        private List<Item> selectItems;
        private Dictionary<char, ICommand> _keyboard_shortcut = new Dictionary<char, ICommand>();
        private Dictionary<char, ICommand> _macroes = new Dictionary<char, ICommand>();
        private Stack<ICommand> _runningCommands = new Stack<ICommand> ();
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
                Console.WriteLine($"{key.KeyChar}?");

                if (key.KeyChar == '1')
                {
                    var res = SetupMacro();
                    if (!res)
                    {
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
                    try 
                    {
                        ICommand command = null;
                        if (_keyboard_shortcut.TryGetValue(key.KeyChar, out command))
                        {
                            command.Execute();
                            _runningCommands.Push(command);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("輸入錯誤，重來");
                        continue;
                    }
                }
            }
        }

        private void PrintQuestion()
        {
            foreach (var item in _macroes)
            {
                var macro = item.Value as Macro;
                Console.WriteLine($"{item.Key}: {macro.Description} ");
            }

            Console.Write("(1) 快捷鍵設置 (2) Undo (3) Redo (字母) 按下按鍵:");
        }

        private char SetupCommand()
        {
            Console.WriteLine();
            var key = Console.ReadKey();
            Console.Write($"Key: {key.KeyChar}");
            Console.WriteLine($"要將哪一道指令設置到快捷鍵 {key.KeyChar}上:");
            for (int i = 0; i < selectItems.Count; i++)
            {
                Console.WriteLine($"({selectItems[i].Key}) {selectItems[i].Description}");
            }
            return key.KeyChar;
        }

        private bool SetupMacro()
        {
            Console.WriteLine();
            Console.Write("設置巨集指令(y / n):");
            var yn = Console.ReadKey();
            Console.Write($"{yn.KeyChar}");
            try
            {
                if (yn.KeyChar.ToString().ToLower() == "y")
                {
                    var key = SetupCommand();
                    var commandLine = Console.ReadLine();
                    var commandKeys = commandLine.Split(" ").Select(p => char.Parse(p)).ToList();
                    var commands = selectItems.Where(p => commandKeys.Contains(p.Key)).ToList();
                    var macro = new Macro(commands);
                    _keyboard_shortcut.Add(key, macro);
                    _macroes.Add(key, macro);
                }
                else if (yn.KeyChar.ToString().ToLower() == "n")
                {
                    var key = SetupCommand();
                    _keyboard_shortcut.Add(key, selectItems.GetCommandByKey(key));
                }
                else
                {
                    return false;
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
            if (_runningCommands != null)
            {
                var redo = _runningCommands.Pop();
                redo.Undo();
            }
        }

        private void Redo()
        {
            if (_runningCommands != null)
            {
                var redo = _runningCommands.Pop();
                redo.Undo();
            }
        }
        public void Reset()
        {
            _keyboard_shortcut.Clear();
            _runningCommands.Clear();
        }
    }
}
