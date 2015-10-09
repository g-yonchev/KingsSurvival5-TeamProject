namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Commons;
    using Contracts;
    using System;

    public class Board : IBoard
    {
        public Board(int totalRows, int totalCols)
        {
            this.TotalRows = totalRows;
            this.TotalCols = totalCols;

            this.Field = new char[this.TotalRows, this.TotalCols];
        }

        public char[,] Field { get; private set; }
        
        public int TotalCols { get; private set; }
        

        public int TotalRows { get; private set; }
    }
}