namespace KingSurvival.GameLogic.Commons
{
    using KingSurvival.GameLogic.Contracts;

    public struct MovementVector
    {
        public MovementVector(int rowMovement, int colMovement)
            : this()
        {
            this.ByRow = rowMovement;
            this.ByCol = colMovement;
        }

        public int ByRow { get; set; }

        public int ByCol { get; set; }
    }
}