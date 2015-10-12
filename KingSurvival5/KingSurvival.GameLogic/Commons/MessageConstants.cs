namespace KingSurvival.GameLogic.Commons
{
    /// <summary>
    /// A class containing the global messages for the application as string constants.
    /// </summary>
    public class MessageConstants
    {
        /// <summary>
        /// Message to be printed when the game is finished.
        /// </summary>
        public const string FinishGameMessage = "Game is finished!";

        /// <summary>
        /// Message to be printed when user enter invalid command name.
        /// </summary>
        public const string InvalidCommandMessage = "Invalid command name!";

        /// <summary>
        /// Message to be printed when user make horrible error.
        /// </summary>
        public const string ErrorMessage = "Sorry, there are some errors, but I can't tell you anything! You broked my program!";

        /// <summary>
        /// Message to be printed when it is king's turn.
        /// </summary>
        public const string KingTurnMessage = "Please enter king's turn: ";

        /// <summary>
        /// Message to be printed when user enter empty command.
        /// </summary>
        public const string EmptyStringMessage = "Empty command!";

        /// <summary>
        /// Message to be printed when it is pawn's turn.
        /// </summary>
        public const string PawnTurnMessage = "Please enter pawn's turn: ";

        /// <summary>
        /// Message to be printed when king win the game.
        /// </summary>
        public const string KingVictoryMessage = "King wins in {0} moves!";

        /// <summary>
        /// Message to be printed when the user enter wrong direction.
        /// </summary>
        public const string WrongDirectionMessage = "You can't go in this direction! ";

        /// <summary>
        /// Message to be printed when king lose the game.
        /// </summary>
        public const string KingLostMessage = "King loses in {0} moves!";

        /// <summary>
        /// Message to be printed when the game is over.
        /// </summary>
        public const string GoodbyeMessage = "\nThank you for playing!\n\n";

        /// <summary>
        /// Empty string.
        /// </summary>
        public const string EmptyString = "";
        
        /// <summary>
        /// Message to be printed when trying to create null figure.
        /// </summary>
        public const string NullFigureErrorMessage = "Figure cannot be null!";

        /// <summary>
        /// Message to be printed when user try to move a pawn over another pawn.
        /// </summary>
        public const string FigureOnTheWayErrorMessage = "There is a figure on your way!";
    }
}