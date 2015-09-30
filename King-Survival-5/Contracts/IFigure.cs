using Models;

namespace Contracts
{
    /// <summary>
    ///  Interface definding figure characteristics.
    /// </summary>
    public interface IFigure
    {
        Position Position { get; }

        void Move(Position position);
    }
}
