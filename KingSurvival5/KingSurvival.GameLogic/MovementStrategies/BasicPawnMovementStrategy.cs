﻿namespace KingSurvival.GameLogic.MovementStrategies
{
    using System.Collections.Generic;
    using KingSurvival.GameLogic.Commons;

    public class BasicPawnMovementStrategy : IMovementStrategy
    {
        public IEnumerable<MovementVector> Get()
        {
            var movements = new List<MovementVector>()
            {
                new MovementVector(1, -1),
                new MovementVector(1, 1),
            };

            return movements;
        }
    }
}