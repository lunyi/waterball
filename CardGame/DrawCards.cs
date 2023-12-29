namespace CardGame
{
    internal class DrawCards
    {
        internal static void DrawCardOutline(int xcoor, int ycoor)
        { 
            Console.ForegroundColor = ConsoleColor.White;
            int x = xcoor * 8;
            int y = ycoor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("_______\n");

            for (int i = 0; i < 5; i++) 
            {
                Console.SetCursorPosition(x, y+1+i);
                Console.Write($"{(i != 4 ? "|      |" : "|______|")}");
            }
        }

        internal static void DrawCardSuitValue(Card card, int xcoor, int ycoor) 
        {
            char cardSuit = ' ';
            int x = xcoor * 8 +1 ;
            int y = ycoor;

            switch (card.Suit)
            {
                case Suit.Heart:
                    cardSuit = '\u2665';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.Diamond:
                    cardSuit = '\u2666';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.Club:
                    cardSuit = '\u2663';
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Suit.Spade:
                    cardSuit = '\u2660';
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.SetCursorPosition(x, y + 1);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x+1, y+3);
            Console.Write(card.Rank);
        }
    }
}
