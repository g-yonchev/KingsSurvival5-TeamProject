namespace KingSurvival.GameLogic.Contracts
{
    /// <summary>
    /// An interface defining all Board public members.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Total rows.
        /// </summary>
        int TotalRows { get; }

        /// <summary>
        /// Total columns.
        /// </summary>
        int TotalCols { get; }

        /// <summary>
        /// Method checks if the given position is unoccupied.
        /// </summary>
        /// <param name="position">The position to be checked.</param>
        /// <returns>The result.</returns>
        bool PositionIsUnoccupied(IPosition position);

        // char[,] Field { get; }
    }
}