namespace KingSurvival.GameLogic.Commons
{
    /// <summary>
    /// The abstract class which provides cloned figure in the game.
    /// </summary>
    public abstract class FigurePrototype
    {
        /// <summary>
        /// The abstract method.
        /// </summary>
        /// <returns>Returned figure prototype.</returns>
        public abstract FigurePrototype Clone();
    }
}