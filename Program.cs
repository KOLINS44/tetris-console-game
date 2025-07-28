
using System;
using System.Threading;

namespace TetrisConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();
            game.Start();
        }
    }
}
