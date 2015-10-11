namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
<<<<<<< HEAD
    using MovementStrategies;
=======
>>>>>>> origin/master

    public class PawnFactory : FigureFactory
    {
        public override IFigure CreateFigure(char symbol, IPosition position)
        {
<<<<<<< HEAD
            return new Pawn(symbol, position, new BasicPawnMovementStrategy());
=======
            return new Pawn("Pawn", position);
>>>>>>> origin/master
        }
    }
}
