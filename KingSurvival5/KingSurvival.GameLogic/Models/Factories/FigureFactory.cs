namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;

    public abstract class FigureFactory
    {
        public abstract IFigure CreateFigure(Position position);
    }
}
