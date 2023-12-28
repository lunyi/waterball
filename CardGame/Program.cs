using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Text;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start();
        }
    }
}