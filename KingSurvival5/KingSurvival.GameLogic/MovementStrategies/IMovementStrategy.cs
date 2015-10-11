namespace KingSurvival.GameLogic.MovementStrategies
{
     using System.Collections.Generic;
    using KingSurvival.GameLogic.Commons;

    public interface IMovementStrategy
    {
        IEnumerable<MovementVector> Get();
    }
}