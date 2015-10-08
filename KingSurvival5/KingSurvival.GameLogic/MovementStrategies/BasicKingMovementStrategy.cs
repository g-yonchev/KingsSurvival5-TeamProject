namespace KingSurvival.GameLogic.MovementStrategies
{
    using System;

    using KingSurvival.GameLogic.Commons;

    public class BasicKingMovementStrategy : IMovementStrategy
    {
        public bool CanMove(Movement movement)
        {
            int rowDistance = Math.Abs(movement.CurrentPosition.Row - movement.NextPosition.Row);
            int colDistance = Math.Abs(movement.CurrentPosition.Col - movement.NextPosition.Col);

            bool canMove = (rowDistance == 1) && (colDistance == 1);

            return canMove;
        }
    }
}