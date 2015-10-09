namespace KingSurvival.GameLogic.Contracts
{
    using Commons;
    using MovementStrategies;

    /// <summary>
    ///  Interface defining figure characteristics.
    /// </summary>
    public interface IFigure
    {
        IPosition Position { get; }
        //void Move(Position position);

        string Name { get; }
    }
}
