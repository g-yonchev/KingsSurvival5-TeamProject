namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Commons;
    using Contracts;
    using System;
   
        public class Board : IBoard
        {
            private readonly IFigure[,] board;

            public Board(
                int rows = GameConstants.BoardRows,
        int cols = GameConstants.BoardRows)
            {
                this.TotalRows = rows;
                this.TotalCols = cols;
                this.board = new IFigure[rows, cols];
            }

            public int TotalRows { get; private set; }

            public int TotalCols { get; private set; }

            public void AddFigure(IFigure figure, Position position)
            {
                Validator.CheckIfObjectIsNull(figure, MessageConstants.NullFigureErrorMessage);
                //TODO
                //Position.CheckIfValid(position);

                int arrRow = this.GetArrayRow(position.Row);
                int arrCol = this.GetArrayCol(position.Col);
                this.board[arrRow, arrCol] = figure;
            }


            public IFigure GetFigureAtPosition(Position position)
            {
                int arrRow = this.GetArrayRow(position.Row);
                int arrCol = this.GetArrayCol(position.Col);
                return this.board[arrRow, arrCol];
            }

            public void MoveFigureAtPosition(IFigure figure, Position from, Position to)
            {
                int arrFromRow = this.GetArrayRow(from.Row);
                int arrFromCol = this.GetArrayCol(from.Col);
                this.board[arrFromRow, arrFromCol] = null;

                int arrToRow = this.GetArrayRow(to.Row);
                int arrToCol = this.GetArrayCol(to.Col);
                this.board[arrToRow, arrToCol] = figure;
            }

            private int GetArrayRow(int currentRow)
            {
                return this.TotalRows - currentRow;
            }

            private int GetArrayCol(int currentCol)
            {
            return this.TotalCols - currentCol;
        
        }
    }
}