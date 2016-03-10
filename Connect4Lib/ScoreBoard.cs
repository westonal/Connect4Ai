using System;

namespace Connect4Lib
{
    public sealed class ScoreBoard
    {
        public readonly int[,] scores = new int[8, 7];

        public ScoreBoard(Game game)
        {
            Score(game.Red);
            //NegateScores();
            Score(game.Green);
        }

        private void NegateScores()
        {
            for (int column = 0; column < 8; column++)
                for (int row = 0; row < 7; row++)
                    scores[column, row] *= -1;
        }

        private void Score(Board board)
        {
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 7; row++)
                {
                    if (board.Pos(column, row))
                    {
                        for (int c2 = column + 1; c2 <= column + 3; c2++)
                            Inc(c2, row);
                        for (int c2 = column - 1; c2 >= column - 3; c2--)
                            Inc(c2, row);
                        for (int r2 = row + 1; r2 <= row + 3; r2++)
                            Inc(column, r2);
                        for (int r2 = row - 1; r2 >= row - 3; r2--)
                            Inc(column, r2);
                    }
                }
            }
        }

        private void Inc(int column, int row)
        {
            if (column < 0) return;
            if (column > 7) return;
            if (row < 0) return;
            if (row > 6) return;
            scores[column, row]++;
        }
    }
}
