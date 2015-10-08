namespace KingSurvival.GameLogic.Models
{
    using System;
    using Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class Pawn : Figure, IFigure
    {
        public Pawn(string name, IMovementStrategy movementStrategy)
            : base(name, movementStrategy)
        {
        }

        public override bool CanMove(Movement movement)
        {
            return this.MovementStrategy.CanMove(movement);
        }
    }
}
