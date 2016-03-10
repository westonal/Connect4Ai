using System;

namespace Connect4Lib
{
    public sealed class Game
    {
        public Game()
        {
            Red = new Board();
            Green = new Board();
        }

        public Board Red { get; private set; }
        public Board Green { get; private set; }
        private int turn;

        public bool Play(int column)
        {
            if (GetPlayerBoard().Play(column, RowForColumn(column)))
            {
                turn = 1 - turn;
                return true;
            }
            return false;
        }

        public int RowForColumn(int column)
        {
            return Math.Min(Red.RowForColumn(column), Green.RowForColumn(column));
        }

        private Board GetPlayerBoard()
        {
            return (turn == 0) ? Green : Red;
        }

        private Board GetOpponentBoard()
        {
            return (turn != 0) ? Green : Red;
        }
    }
}