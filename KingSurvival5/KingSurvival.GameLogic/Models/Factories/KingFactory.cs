namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;

    public class KingFactory : FigureFactory
    {
        public override IFigure CreateFigure(Position position)
        {
            return new KingFigure(position);
        }
    }
}
