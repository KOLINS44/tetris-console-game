
using System;
using System.Collections.Generic;

namespace TetrisConsoleGame
{
    class Tetromino
    {
        private int[,] shape;
        private int x, y;

        private static List<int[,]> shapes = new List<int[,]>
        {
            new int[,] {{1,1,1,1}}, // I
            new int[,] {{1,1},{1,1}}, // O
            new int[,] {{0,1,0},{1,1,1}}, // T
            new int[,] {{1,0,0},{1,1,1}}, // J
            new int[,] {{0,0,1},{1,1,1}}, // L
            new int[,] {{1,1,0},{0,1,1}}, // S
            new int[,] {{0,1,1},{1,1,0}}, // Z
        };

        public Tetromino(int[,] shape)
        {
            this.shape = shape;
            this.x = 3;
            this.y = 0;
        }

        public void Move(int dx, int dy, Field field)
        {
            if (field.CanMove(this, dx, dy))
            {
                x += dx;
                y += dy;
            }
        }

        public void Rotate(Field field)
        {
            int[,] rotated = new int[shape.GetLength(1), shape.GetLength(0)];
            for (int i = 0; i < shape.GetLength(0); i++)
                for (int j = 0; j < shape.GetLength(1); j++)
                    rotated[j, shape.GetLength(0) - i - 1] = shape[i, j];

            var backup = shape;
            shape = rotated;
            if (!field.CanPlace(this))
                shape = backup;
        }

        public List<(int, int)> GetBlocks(int dx = 0, int dy = 0)
        {
            var blocks = new List<(int, int)>();
            for (int i = 0; i < shape.GetLength(0); i++)
                for (int j = 0; j < shape.GetLength(1); j++)
                    if (shape[i, j] == 1)
                        blocks.Add((x + j + dx, y + i + dy));
            return blocks;
        }

        public static Tetromino GetRandom(Random rnd)
        {
            return new Tetromino(shapes[rnd.Next(shapes.Count)]);
        }
    }
}
