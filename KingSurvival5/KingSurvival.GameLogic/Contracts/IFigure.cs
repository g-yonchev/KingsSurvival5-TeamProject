namespace KingSurvival.GameLogic.Contracts
{
    using System.Collections.Generic;
    using Commons;
    using MovementStrategies;

    /// <summary>
    ///  Interface defining figure characteristics.
    /// </summary>
    public interface IFigure
    {
        IPosition Position { get; }

        char Symbol { get; }

        IMovementStrategy MovementStrategy { get; }

        IEnumerable<MovementVector> GetMovements();
    }
}