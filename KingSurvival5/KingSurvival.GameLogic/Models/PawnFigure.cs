namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Contracts;

    public class PawnFigure : Figure, IFigure
    {
        public PawnFigure(Position position)
            : base(position)
        {
        }

        public override void Move(Position position)
        {
            this.Position = position;
        }
    }
}
