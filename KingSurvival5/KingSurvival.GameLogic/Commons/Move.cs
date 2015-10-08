namespace KingSurvival.GameLogic.Commons
{
    using KingSurvival.GameLogic.Contracts;

    public class Move
    {
        public Move(IPosition currentPosition, IPosition nextPosition)
        {
            this.CurrentPosition = currentPosition;
            this.NextPosition = nextPosition;
        }

        public IPosition CurrentPosition { get; set; }

        public IPosition NextPosition { get; set; }
    }
}