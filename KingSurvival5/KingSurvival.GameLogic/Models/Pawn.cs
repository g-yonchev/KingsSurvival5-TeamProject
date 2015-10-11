namespace KingSurvival.GameLogic.Models
{
    using System;
    using Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class Pawn : Figure, IFigure
    {
        public Pawn(char symbol, IPosition position, IMovementStrategy movementStrategy)
            : base(symbol, position, movementStrategy)
        {
        }
    }
}
