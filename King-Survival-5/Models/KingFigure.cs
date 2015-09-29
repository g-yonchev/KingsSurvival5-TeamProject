namespace Models
{
    using Contracts;

    public class KingFigure : Figure, IFigure
    {
        public int MovesCounter { get; set; }

        public KingFigure(Position position)
            : base(position)
        {
            this.MovesCounter = 0;
        }

        public override void Move(Position position)
        {
            this.Position = position;
            this.MovesCounter++;
        }
    }
}
