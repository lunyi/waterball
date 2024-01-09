namespace _7.CommandPattern
{
    internal class TelecomDisconnectCommand : ICommand
    {
        private Telecom _telecom;
        public TelecomDisconnectCommand(Telecom telecom)
        {
            _telecom = telecom;
        }
        public void Execute()
        {
            _telecom.Disconnect();
        }
        public void Undo()
        {
            _telecom.Connect();
        }
    }
}
