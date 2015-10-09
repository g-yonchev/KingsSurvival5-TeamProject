namespace KingSurvival.GameLogic.Models
{
    using System;
    using Commons;
    using KingSurvival.GameLogic.Contracts;
    using MovementStrategies;

    public class Pawn : Figure, IFigure
    {
        public Pawn(string name, IPosition position)
            : base(name, position)
        {

        }
    }
}
