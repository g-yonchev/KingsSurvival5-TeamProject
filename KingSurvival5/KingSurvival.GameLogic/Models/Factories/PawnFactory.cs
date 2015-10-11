namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class PawnFactory : FigureFactory
    {
        public override IFigure CreateFigure(char symbol, IPosition position)
        {
            return new Pawn(symbol, position, new BasicPawnMovementStrategy());
        }
    }
}
