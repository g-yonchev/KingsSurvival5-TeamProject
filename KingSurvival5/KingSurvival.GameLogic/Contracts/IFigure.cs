namespace KingSurvival.GameLogic.Contracts
{
    using Commons;
    using MovementStrategies;

    /// <summary>
    ///  Interface defining figure characteristics.
    /// </summary>
    public interface IFigure
    {
        //Position Position { get; }
        //void Move(Position position);

        string Name { get; }

        IMovementStrategy MovementStrategy { get; }

        bool CanMove(Movement move);
    }
}
