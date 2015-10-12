namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    /// <summary>
    /// Concrete Pawn factory.
    /// </summary>
    public class PawnFactory : FigureFactory
    {
        /// <summary>
        /// Method to create a pawn.
        /// </summary>
        /// <param name="symbol">Given symbol represents which one pawn.</param>
        /// <param name="position">Position of the pawn.</param>
        /// <returns>The concrete pawn.</returns>
        public override IFigure CreateFigure(char symbol, IPosition position)
        {
            return new Pawn(symbol, position, new BasicPawnMovementStrategy());
        }
    }
}