namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Contracts;

    public abstract class Figure : FigurePrototype, IFigure
    {
        protected Figure(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; protected set; }

        public abstract void Move(Position position);

        public override FigurePrototype Clone()
        {
            return this.MemberwiseClone() as FigurePrototype;
        }
    }
}
