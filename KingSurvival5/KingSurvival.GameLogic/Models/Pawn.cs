namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Contracts;

    public class Pawn : Figure, IFigure
    {
        public Pawn(Position position)
            : base(position)
        {
        }

        public override void Move(Position position)
        {
            this.Position = position;
        }
    }
}
