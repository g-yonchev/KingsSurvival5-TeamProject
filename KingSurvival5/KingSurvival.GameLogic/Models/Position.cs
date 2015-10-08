namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Contracts;

    public class Position : IPosition
    {
        // Probably, there's no need of empty ctor. It is here for now in order to not break the code.
        public Position()
        {
        }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
