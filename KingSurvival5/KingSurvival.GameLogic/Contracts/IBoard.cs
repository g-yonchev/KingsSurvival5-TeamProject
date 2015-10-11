namespace KingSurvival.GameLogic.Contracts
{
    using KingSurvival.GameLogic.Models;

    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get; }

        bool PositionIsUnoccupied(IPosition position);

       // char[,] Field { get; }
    }
}
