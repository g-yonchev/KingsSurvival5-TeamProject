namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    // Factory method or smth...
    public abstract class FigureFactory
    {
        public abstract IFigure CreateFigure(char symbol, IPosition);
    }
}
