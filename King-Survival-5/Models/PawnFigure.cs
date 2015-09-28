namespace Models
{
    using Contarcts;

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
