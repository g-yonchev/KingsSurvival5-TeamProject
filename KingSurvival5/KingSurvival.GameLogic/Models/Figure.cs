namespace KingSurvival.GameLogic.Models
{
    using System.Collections.Generic;

    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public abstract class Figure : FigurePrototype, IFigure
    {
        protected Figure(char symbol, IPosition position, IMovementStrategy movementStrategy)
        {
            this.Symbol = symbol;
            this.Position = position;
            this.MovementStrategy = movementStrategy;
        }

        public char Symbol { get; set; }

        public IPosition Position { get; set; }

        public IMovementStrategy MovementStrategy { get; set; }

        public IEnumerable<MovementVector> GetMovements()
        {
            return this.MovementStrategy.Get();
        }

        public override FigurePrototype Clone()
        {
            return this.MemberwiseClone() as FigurePrototype;
        }
    }
}
