namespace CardGame
{
    internal class ExchangeHands
    {     
        private int roundCountDown = 3;
        private Player? humanPlayer;
        private List<Player> _players;
        private List<Player> _aiplayers;
        public ExchangeHands(List<Player> players)
        {
            _players = players;
            humanPlayer = _players.FirstOrDefault(p => p is HumanPlayer);
            _aiplayers = _players.Where(p => p is AIPlayer).ToList();
        }

        public void Run()
        {
            if (roundCountDown != 0)
            {
                Console.WriteLine("Does any one want to change hand? Y or N");
                var res = Console.ReadLine();
                
                var changeHandPlayers = new List<Player>();
                changeHandPlayers.CopyTo(_players.ToArray());
                for (int i = 0; i < changeHandPlayers.Count; i++)
                {
                    if (changeHandPlayers[i].makeExchangeHandsDecision())
                    {
                        var exchanger = changeHandPlayers[i];
                        changeHandPlayers.RemoveAt(i);
                        ExchangeBack(exchanger, changeHandPlayers);
                    }
                }
            }

        }
        public void ExchangeBack(Player exchange, List<Player> exchangees)
        {

            roundCountDown--;
        }

        public int GetRoundCountDown() 
        {
            return roundCountDown;
        }
    }
}
