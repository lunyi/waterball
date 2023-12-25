using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class DrawCards
    {
        internal static void DrawCardOutline(int xcoor, int ycoor)
        { 
            Console.ForegroundColor = ConsoleColor.White;
            int x = xcoor * 12;
            int y = ycoor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("_______________\n");

            for (int i = 0; i < 10; i++) 
            {
                Console.SetCursorPosition((int)x, (int)y+1+i);

                if (i != 9)
                    Console.WriteLine("|             |");
                else 
                    Console.WriteLine("|_____________|");
            }
        }

        internal static void DrawCardSuitValue(Card card, int xcoor, int ycoor) 
        {
            char cardSuit = ' ';
            int x = xcoor = 12;
            int y = ycoor;

            switch (card.Suits)
            {
                case Suit.Heart:
                    cardSuit = '\u2665';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.Diamond:
                    cardSuit = '\u2666';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.club:
                    cardSuit = '\u2663';
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Suit.Spade:
                    cardSuit = '\u2660';
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            Console.SetCursorPosition(x, y);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x+4, y+7);
            Console.Write(card.Ranks);
        }
    }
}
