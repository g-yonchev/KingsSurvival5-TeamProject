namespace KingSurvival.GameLogic.Models
{
    using Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class King : Figure, IFigure
    {
        private const int InitialMovesCount = 0;

        public King(string name, IMovementStrategy movementStrategy)
            : base(name, movementStrategy)
        {
            this.MovesCount = InitialMovesCount;
        }

        public int MovesCount { get; private set; }

        public override bool CanMove(Movement movement)
        {
            return this.MovementStrategy.CanMove(movement);
        }

        public void UpdateMovesCount()
        {
            this.MovesCount += 1;
        }
    }
}