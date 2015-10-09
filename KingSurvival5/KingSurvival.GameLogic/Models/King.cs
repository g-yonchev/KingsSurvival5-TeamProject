namespace KingSurvival.GameLogic.Models
{
    using Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class King : Figure, IFigure
    {
        private const int InitialMovesCount = 0;

        public King(string name, IPosition position)
            : base(name, position)
        {
        }

        public int MovesCount { get; private set; }

    }
}