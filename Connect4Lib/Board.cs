using System;

namespace Connect4Lib
{
    public sealed class Board
    {
        private const int WIDTH = 8;
        private const int HEIGHT = 7;

        private bool[,] grid = new bool[WIDTH, HEIGHT];

        public bool Play(int column)
        {
            int y = RowForColumn(column);
            if (y == -1) return false;

            grid[column, y] = true;
            return true;
        }

        internal bool Play(int column, int row)
        {
            if (row == -1) return false;
            grid[column, row] = true;
            return true;
        }

        public bool Pos(int column, int y)
        {
            return grid[column, y];
        }

        public int RowForColumn(int column)
        {
            for (int y = 0; y < HEIGHT; y++)
                if (grid[column, y])
                    return y - 1;
            return HEIGHT - 1;
        }
    }
}
