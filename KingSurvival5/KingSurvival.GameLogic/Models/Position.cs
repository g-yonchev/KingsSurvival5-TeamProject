namespace KingSurvival.GameLogic.Models
{
    using System;

    using KingSurvival.GameLogic.Contracts;

    public class Position : IPosition
    {
        private const string ExceptionMessage = "Position's coordinates must be positive values.";

        private int row;

        private int col;

        // Probably, there's no need of empty ctor. It is here for now in order to not break the code.
        public Position()
        {
        }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                this.col = value;
            }
        }
    }
}