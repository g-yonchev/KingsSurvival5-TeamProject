namespace King
{
    /// <summary>
    ///  Interface definding figure characteristics.
    /// </summary>
    interface IFigure
    {
        Position Position { get; }

        void Move(Position position);
    }
}
