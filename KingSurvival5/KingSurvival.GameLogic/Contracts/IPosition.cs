namespace KingSurvival.GameLogic.Contracts
{
    /// <summary>
    ///  An interface defining all Position public members.
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// Row represents X coordinate.
        /// </summary>
        int Row { get; }

        /// <summary>
        /// Col represents Y coordinate.
        /// </summary>
        int Col { get; }
    }
}