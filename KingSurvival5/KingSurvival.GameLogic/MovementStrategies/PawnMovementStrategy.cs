namespace KingSurvival.GameLogic.MovementStrategies
{
    using KingSurvival.GameLogic.Commons;

    public class PawnMovementStrategy : IMovementStrategy
    {
        public bool CanMove(Movement movement)
        {
            int rowDistance = movement.CurrentPosition.Row - movement.NextPosition.Row;
            int colDistance = movement.CurrentPosition.Col - movement.NextPosition.Col;

            bool movementIsDownLeft = (rowDistance == -1) && (colDistance == 1);
            if (movementIsDownLeft)
            {
                return true;
            }

            bool movementIsDownRight = (rowDistance == 1) && (colDistance == -1);
            if (movementIsDownRight)
            {
                return true;
            }

            return false;
        }
    }
}