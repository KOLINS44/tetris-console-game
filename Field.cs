
using System;

namespace TetrisConsoleGame
{
    class Field
    {
        public int Width { get; }
        public int Height { get; }
        private int[,] matrix;

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            matrix = new int[height, width];
        }

        public bool CanPlace(Tetromino t)
        {
            foreach (var (x, y) in t.GetBlocks())
            {
                if (y < 0 || y >= Height || x < 0 || x >= Width || matrix[y, x] == 1)
                    return false;
            }
            return true;
        }

        public bool CanMove(Tetromino t, int dx, int dy)
        {
            foreach (var (x, y) in t.GetBlocks(dx, dy))
            {
                if (y < 0 || y >= Height || x < 0 || x >= Width || matrix[y, x] == 1)
                    return false;
            }
            return true;
        }

        public void Merge(Tetromino t)
        {
            foreach (var (x, y) in t.GetBlocks())
                matrix[y, x] = 1;
        }

        public void Place(Tetromino t) { } // Пустышка — отрисовка идёт отдельно

        public void Render()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                    Console.Write(matrix[y, x] == 1 ? "#" : ".");
                Console.WriteLine();
            }
        }
    }
}
