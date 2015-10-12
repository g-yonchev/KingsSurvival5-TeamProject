namespace KingSurvival.GameLogic.Contracts
{
    using System.Collections.Generic;
    using Commons;
    using MovementStrategies;

    /// <summary>
    ///  An interface defining all Figure public members.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Position of the figure.
        /// </summary>
        IPosition Position { get; }

        /// <summary>
        /// Char represents the symbol of the figure.
        /// </summary>
        char Symbol { get; }

        /// <summary>
        /// Movement strategy.
        /// </summary>
        IMovementStrategy MovementStrategy { get; }

        IEnumerable<MovementVector> GetMovements();
    }
}