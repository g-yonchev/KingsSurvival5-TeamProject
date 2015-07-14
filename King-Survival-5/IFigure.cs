namespace King
{
    interface IFigure
    {
        Position Position { get; }

        void Move(Position position);
    }
}
