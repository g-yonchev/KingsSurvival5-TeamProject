namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Commons;
    using Contracts;
    using System;

    public class Board : IBoard
    {
        private char[,] field;

        public Board(int totalRows, int totalCols)
        {
            this.TotalRows = totalRows;
            this.TotalCols = totalCols;

            this.GenerateField();
        }

       // public char[,] Field { get; private set; }
        
        public int TotalCols { get; private set; }
        
        public int TotalRows { get; private set; }

        public bool PositionIsUnoccupied(IPosition position)
        {
            bool isUnoccupied = this.field[position.Row, position.Col] == ' ';
            return isUnoccupied;
        }

        private void GenerateField()
        {
            this.field = new char[this.TotalRows, this.TotalCols];

            for (int r = 0; r < this.TotalRows; r++)
            {
                for (int c = 0; c < this.TotalCols; c++)
                {
                    this.field[r, c] = ' ';
                }
            }
        }
    }
}