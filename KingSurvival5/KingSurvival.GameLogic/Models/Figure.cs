namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public abstract class Figure : FigurePrototype, IFigure
    {
        protected Figure(string name, IPosition position)
        {
            this.Name = name;
            this.Position = position;
        }

        public string Name { get; set; }

        public IPosition Position { get; set; }

        public override FigurePrototype Clone()
        {
            return this.MemberwiseClone() as FigurePrototype;
        }
    }
}
