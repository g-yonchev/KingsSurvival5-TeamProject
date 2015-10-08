namespace KingSurvival.GameLogic.MovementStrategies
{
    using KingSurvival.GameLogic.Commons;

    public interface IMovementStrategy
    {
        bool CanMove(Movement movement);
    }
}