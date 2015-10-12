namespace KingSurvival.GameLogic.Models.Factories
{
    using KingSurvival.GameLogic.Contracts;

    /// <summary>
    /// An abstract factory for creating a figure.
    /// </summary>
    public abstract class FigureFactory
    {
        /// <summary>
        /// An abstract method to create an abstract figure.
        /// </summary>
        /// <param name="symbol">Symbol represents what kind of figure is going to be created.</param>
        /// <param name="position">Position for the concrete figure.</param>
        /// <returns>Created concrete figure.</returns>
        public abstract IFigure CreateFigure(char symbol, IPosition position);
    }
}