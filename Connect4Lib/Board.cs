namespace Connect4Lib
{
    public sealed class Board
    {
        private const int WIDTH=8;
        private const int HEIGHT = 7;

        private bool[,] grid = new bool[WIDTH,HEIGHT];

        public bool Play(int column)
        {
            for (int y = 6; y >= 0; y--)
                if (!grid[column, y])
                {
                    grid[column, y] = true;
                    return true;
                }
            return false;
        }

        public bool Pos(int column, int y)
        {
            return grid[column, y];
        }
    }
}
