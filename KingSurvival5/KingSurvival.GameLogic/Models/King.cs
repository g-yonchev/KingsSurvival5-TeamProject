namespace KingSurvival.GameLogic.Models
{
    using Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class King : Figure, IFigure
    {
        private const int InitialMovesCount = 0;

        public King(char symbol, IPosition position, IMovementStrategy movementStrategy)
            : base(symbol, position, movementStrategy)
        {
            this.MovesCount = InitialMovesCount;
        }

        public int MovesCount { get; private set; }
<<<<<<< HEAD
=======


        internal void Move(IPosition newPosition)
        {
            this.Position = newPosition;
        }
>>>>>>> origin/master
    }
}