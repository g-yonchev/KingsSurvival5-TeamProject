namespace King
{
    public struct Position : IPosition
    {
        public Position(int x, int y)
            : this()
        {
            this.Row = x;
            this.Col = y;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
