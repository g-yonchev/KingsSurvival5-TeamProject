namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Contracts;

    public class King : Figure, IFigure
    {
        private const int InitialMovesCount = 0;

        public int MovesCount { get; private set; }

        public King(Position position)
            : base(position)
        {
            this.MovesCount = InitialMovesCount;
        }

        public override void Move(Position position)
        {
            this.Position = position;
            this.MovesCount++;
        }
    }
}
