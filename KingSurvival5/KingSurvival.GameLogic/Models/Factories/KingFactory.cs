namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    /// <summary>
    /// Concrete King factory.
    /// </summary>
    public class KingFactory : FigureFactory
    {
        /// <summary>
        /// Method to create a king.
        /// </summary>
        /// <param name="symbol">Given symbol represents the king.</param>
        /// <param name="position">Position of the king.</param>
        /// <returns>The king.</returns>
        public override IFigure CreateFigure(char symbol, IPosition position)
        {
            return new King(symbol, position, new BasicKingMovementStrategy());
        }
    }
}