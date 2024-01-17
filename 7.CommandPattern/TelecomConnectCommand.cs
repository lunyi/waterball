namespace _7.CommandPattern
{
    internal class TelecomConnectCommand : ICommand
    {
        private Telecom _telecom;
        public TelecomConnectCommand(Telecom telecom)
        {
            _telecom = telecom;
        }
        public void Execute()
        {
            _telecom.Connect();
        }
        public void Undo()
        {
            _telecom.Disconnect();
        }
    }
}
