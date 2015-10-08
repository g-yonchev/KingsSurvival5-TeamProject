namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;
    
    public class PawnFactory : FigureFactory
    {
        public override IFigure CreateFigure(Position position)
        {
            return new Pawn(position);
        }
    }
}
