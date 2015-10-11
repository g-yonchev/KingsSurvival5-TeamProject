namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class KingFactory : FigureFactory
    {
        public override IFigure CreateFigure(char symbol, IPosition position)
        {
<<<<<<< HEAD
            return new King(symbol, position, new BasicKingMovementStrategy());
=======
            return new King("King", position);
>>>>>>> origin/master
        }
    }
}
