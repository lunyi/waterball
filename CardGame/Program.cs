using System.Runtime.ExceptionServices;
using System.Text;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Console.SetWindowSize(130, 100);
            Console.OutputEncoding = Encoding.UTF8;

            //DrawCards.DrawCardOutline(0, 0);
            //Card card = new Card(Suit.Heart, Rank.Ace);
            //DrawCards.DrawCardSuitValue(card, 0, 0);

            //Card card2 = new Card(Suit.club, Rank.Two);
            //DrawCards.DrawCardOutline(1, 0);
            //DrawCards.DrawCardSuitValue(card2, 1, 0);

            var quit = false;
            var input = false;
            string playername = "";
            while (!quit)
            {
                string name = string.Empty;
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
                ClearCurrentConsoleLine();

                var players = GetPlayers(playername);
                var deck = new Deck();
                deck.SetUpDeck();

                foreach (var player in players) 
                {
                    for (int i = 0; i < 13; i++) 
                    {
                        player.AddHandCard(deck.DrawCard());
                    }
                }

                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, 1);

                for (int j = 0; j < 13; j++)
                {
                    if (j < 10)
                        Console.Write("   "+ (j + 1)+"    ");
                    else
                        Console.Write("  " + (j + 1)+ "   ");
                }

                var y = 2;
                for (int i = 0; i < players.Length; i++)
                {
                    var cards =  players[i].ShowCards();

                    Console.SetCursorPosition(0, y);
                    Console.ForegroundColor = i==0 ? ConsoleColor.Blue: ConsoleColor.Yellow;

                    Console.WriteLine(players[i].GetPlayerName());

                    for (int j = 0; j < 13; j++)
                    {
                        Thread.Sleep(100);
                        var c = new Card(cards[j].Suits, cards[j].Ranks);
                        DrawCards.DrawCardOutline(j, y+1);
                        DrawCards.DrawCardSuitValue(c, j, y+1);
                    }
                    y = y + 7;
                }

                Console.SetCursorPosition(0, Console.CursorTop+3);
                

                while (players[0].ShowCards().Length > 0)
                {
                    Console.WriteLine("Which card do you want to pick up?");
                    var cards = new Dictionary<Player, Hand>();
                    var t = Console.ReadKey();

                    while (true)
                    {
                        try
                        {
                            int playerIndex = Convert.ToInt32(t);
                            var plauerCard = players[0].PickupCard(playerIndex);
                            cards.Add(players[0], plauerCard);
                            continue;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }

                    
                    for (int i = 1;i < 3;i++) 
                    {
                        var card = players[i].PickupCard(r.Next(players[0].ShowCards().Length - 1));
                        cards.Add(players[i], card);
                    }
                    
                }
                


            }
            Console.ReadKey();
        }

        Player GetWinner(Dictionary<Player, Hand> players)
        {


        }
        static void ClearCurrentConsoleLine()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.WriteLine();
            }
        }

        static Player[] GetPlayers(string name)
        {
            List<Player> list = new List<Player>();
            var p = new HumanPlayer();
            p.NameHimself(name);
            list.Add(p);

            var names = GetAINames();
            for (int i = 0; i < 3; i++)
            {
                var aip = new AIPlayer();
                aip.NameHimself(names[i]);
                list.Add(aip);
            }
            return list.ToArray();
        }
        static string[] GetAINames()
        {
            string[] englishNames = {
            "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Henry", "Ivy", "Jack",
            "Katherine", "Leo", "Mia", "Nathan", "Olivia", "Paul", "Quinn", "Ryan", "Sophie", "Tom"
        };

            Random random = new Random();
            
            List<string> names = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = random.Next(englishNames.Length);
                string randomName = englishNames[randomIndex];
                names.Add(randomName);
            }
            return names.ToArray();
        }
    }
}