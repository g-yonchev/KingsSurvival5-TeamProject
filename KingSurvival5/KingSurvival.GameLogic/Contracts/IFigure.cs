namespace KingSurvival.GameLogic.Contracts
{
    using KingSurvival.GameLogic.Models;

    /// <summary>
    ///  Interface definding figure characteristics.
    /// </summary>
    public interface IFigure
    {
        Position Position { get; }

        void Move(Position position);
    }
}
