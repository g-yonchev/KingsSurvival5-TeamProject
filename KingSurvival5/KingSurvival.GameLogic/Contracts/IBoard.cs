namespace KingSurvival.GameLogic.Contracts
{
    using KingSurvival.GameLogic.Models;

    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get; }

        void AddFigure(IFigure figure, Position position);

        IFigure GetFigureAtPosition(Position position);

        void MoveFigureAtPosition(IFigure figure, Position from, Position to);
    }
}
