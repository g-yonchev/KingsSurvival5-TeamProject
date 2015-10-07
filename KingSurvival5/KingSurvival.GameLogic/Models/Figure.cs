namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Contracts;

    public abstract class Figure : IFigure
    {
        protected Figure(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; protected set; }

        public abstract void Move(Position position);
    }
}
