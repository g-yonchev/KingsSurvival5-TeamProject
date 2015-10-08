namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public abstract class Figure : FigurePrototype, IFigure
    {
        protected Figure(string name, IMovementStrategy movementStrategy)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public IMovementStrategy MovementStrategy { get; protected set; }

        public abstract bool CanMove(Movement movement);

        public override FigurePrototype Clone()
        {
            return this.MemberwiseClone() as FigurePrototype;
        }
    }
}
