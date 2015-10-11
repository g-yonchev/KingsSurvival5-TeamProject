namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;

    // Factory method or smth...
    public abstract class FigureFactory
    {
        public abstract IFigure CreateFigure(char symbol, IPosition position);
    }
}