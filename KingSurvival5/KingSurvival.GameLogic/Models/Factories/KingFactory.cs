namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class KingFactory : FigureFactory
    {
        public override IFigure CreateFigure(char symbol, Position position, IMovementStrategy movementStrategy)
        {
            return new King(symbol, position, movementStrategy);
        }
    }
}
