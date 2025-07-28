
using System;
using System.Threading;

namespace TetrisConsoleGame
{
    class Game
    {
        private Field field;
        private Tetromino current;
        private Random random = new Random();

        public void Start()
        {
            field = new Field(10, 20);
            current = Tetromino.GetRandom(random);
            while (true)
            {
                if (!field.CanPlace(current))
                {
                    Console.Clear();
                    Console.WriteLine("Игра окончена!");
                    Console.WriteLine("Нажмите любую клавишу, чтобы начать заново...");
                    Console.ReadKey();
                    Start();
                    return;
                }

                field.Place(current);
                field.Render();
                Thread.Sleep(500);

                ConsoleKeyInfo key = Console.KeyAvailable ? Console.ReadKey(true) : new ConsoleKeyInfo();
                if (key.Key == ConsoleKey.LeftArrow) current.Move(-1, 0, field);
                if (key.Key == ConsoleKey.RightArrow) current.Move(1, 0, field);
                if (key.Key == ConsoleKey.DownArrow) current.Move(0, 1, field);
                if (key.Key == ConsoleKey.UpArrow) current.Rotate(field);

                current.Move(0, 1, field);

                if (!field.CanMove(current, 0, 1))
                {
                    field.Merge(current);
                    current = Tetromino.GetRandom(random);
                }
                Console.Clear();
            }
        }
    }
}
