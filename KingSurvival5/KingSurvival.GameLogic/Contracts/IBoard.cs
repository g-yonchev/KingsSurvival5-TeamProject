namespace KingSurvival.GameLogic.Contracts
{
    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get; }

        bool PositionIsUnoccupied(IPosition position);

        // char[,] Field { get; }
    }
}