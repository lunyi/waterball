using System.Text;

namespace CardGame
{
    internal class Game
    {
        public void Start() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(130, 300);
            Console.OutputEncoding = Encoding.UTF8;

            var quit = false;
            var input = false;
            string playername = string.Empty;
            while (!quit)
            {
                if (!input)
                {
                    Console.WriteLine("What's your name?");
                    playername = Console.ReadLine();

                    if (string.IsNullOrEmpty(playername))
                    {
                        break;
                    }
                }
                input = true;

                var players = InitPlayerCards(playername);

                DrawCardsOfPlayers(players);
                Thread.Sleep(100);

                var makeChangeHand = new ExchangeHands(players);
                RunRound(players, makeChangeHand);
               
            }
            Console.ReadKey();
        }

        private void RunRound(List<Player> players, ExchangeHands makeChangeHand)
        {
            while (players.SingleOrDefault(p=>p is HumanPlayer).GetHand().Size() > 0)
            {
            // label
            repeat:
                makeChangeHand.Run();

                Console.WriteLine("Which card do you want to pick up?");
                var eachRound = new List<Hand>();
                var t = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        var player = players[0];
                        var index = Convert.ToInt32(t);
                        if (index <= 0 && index > players[0].GetHand().Size())
                        {
                            goto repeat;
                        }

                        player.TakeTurn();
                        eachRound.Add(player.GetHand());
                        break;
                    }
                    catch (Exception)
                    {
                        goto repeat;
                    }
                }

                for (int i = 1; i <= 3; i++)
                {
                    players[i].TakeTurn();
                    eachRound.Add(players[i].GetHand());
                }

                Console.WriteLine();
                DrawRound(eachRound);
                Console.WriteLine();
                GetWinner(eachRound);
                Console.ReadKey();
                Console.Clear();
                DrawCardsOfPlayers(players);
            }
        }
        private void GetWinner(List<Hand> hands)
        {
            var tmpHands = new List<Hand>();
            Hand tmpHand;
            tmpHands.AddRange(hands);

            for (int i = 0; i < tmpHands.Count; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < tmpHands.Count - 1; j++)
                {
                    var firstHandRank = tmpHands[j].CurrentCard.Ranks;
                    var secondHandRank = tmpHands[j + 1].CurrentCard.Ranks;

                    if (secondHandRank > firstHandRank)
                    {
                        tmpHand = tmpHands[j];
                        tmpHands[j] = tmpHands[j + 1];
                        tmpHands[j + 1] = tmpHand;
                    }
                    else if (firstHandRank == secondHandRank)
                    {
                        var firstHandSuit = tmpHands[j].CurrentCard.Suits;
                        var secondHandSuit = tmpHands[j + 1].CurrentCard.Suits;

                        if (secondHandSuit > firstHandSuit)
                        {
                            tmpHand = tmpHands[j];
                            tmpHands[j] = tmpHands[j + 1];
                            tmpHands[j + 1] = tmpHand;
                        }
                    }
                }
            }

            tmpHands[0].Player.AddPoint();
            Console.WriteLine();
            Thread.Sleep(200);
            Console.WriteLine();

            var result = $"(The Winner of this round is {tmpHands[0].Player.GetPlayerName()})\n";

            for (int j = 0; j < tmpHands.Count; j++)
            {
                var player = tmpHands[j].Player;
                result += $"{player.GetPlayerName()}: {player.GainPoint()} points\n";
            }
            Console.WriteLine(result);
        }
        private void DrawRound(List<Hand> hands)
        {
            Console.WriteLine();
            Console.WriteLine();
            var y = Console.CursorTop;

            for (int i = 0; i < hands.Count; i++)
            {
                Console.Write("  ");
                DrawCards.DrawCardOutline(i, y + 1);
                DrawCards.DrawCardSuitValue(hands[i].CurrentCard, i, y + 1);
            }
            Thread.Sleep(500);
            Console.WriteLine();

            for (int i = 0; i < hands.Count; i++)
            {
                Console.ForegroundColor = i == 0 ? ConsoleColor.Blue : ConsoleColor.White;
                Console.Write(" " + hands[i].Player.GetPlayerName() + "  ");
            }
        }
        static void ClearCurrentConsoleLine()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.WriteLine();
            }
        }
        private List<Player> GetPlayers(string name)
        {
            var players = new List<Player>();
            var p = new HumanPlayer();
            p.NameHimself(name);
            players.Add(p);

            var names = GetAIPlayerNames();
            for (int i = 0; i < 3; i++)
            {
                var aip = new AIPlayer();
                aip.NameHimself(names[i]);
                players.Add(aip);
            }
            return players;
        }
        private string[] GetAIPlayerNames()
        {
            string[] englishNames = {
            "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Henry", "Ivy", "Jack",
            "Katherine", "Leo", "Mia", "Nathan", "Olivia", "Paul", "Quinn", "Ryan", "Sophie", "Tom"
        };

            Random random = new Random();

            List<string> names = new List<string>();
            while (names.Count<=3)
            {
                int randomIndex = random.Next(englishNames.Length);
                string randomName = englishNames[randomIndex];

                if (!names.Contains(randomName)) 
                {
                    names.Add(randomName);
                }   
            }
            return names.ToArray();
        }
        private List<Player> InitPlayerCards(string playername)
        {
            var players = GetPlayers(playername);
            var deck = new Deck();

            foreach (var player in players)
            {
                for (int i = 0; i < 13; i++)
                {
                    player.AddHandCard(deck.DrawCard());
                }
            }
            return players;
        }
        private void DrawCardsOfPlayers(List<Player> players)
        {
            ClearCurrentConsoleLine();
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.White;
            var y = 2;
            for (int i = players.Count - 1; i >= 0; i--)
            {
                var cards = players[i].ShowCards();

                Console.SetCursorPosition(0, y);
                Console.ForegroundColor = players[i] is HumanPlayer ? ConsoleColor.Blue : ConsoleColor.Yellow;

                Console.WriteLine(players[i].GetPlayerName());

                for (int j = 0; j < cards.Length; j++)
                {
                    //Thread.Sleep(100);
                    var c = new Card(cards[j].Suits, cards[j].Ranks);
                    DrawCards.DrawCardOutline(j, y + 1);
                    DrawCards.DrawCardSuitValue(c, j, y + 1);
                }
                y = y + 7;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int j = 0; j < players[0].GetHand().Size(); j++)
            {
                if (j < 10)
                    Console.Write("   " + (j + 1) + "    ");
                else
                    Console.Write("   " + (j + 1) + "   ");
            }
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine();
        }
    }

    static class Extension
    { 
        
    }
}
