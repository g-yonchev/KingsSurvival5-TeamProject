namespace KingSurvival.GameLogic.Commons
{
    using System;
    using System.Text.RegularExpressions;

    using Contracts;

    /// <summary>
    /// A class validating figure's moves and basic commands.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Indicates if the pawn's move is valid.
        /// </summary>
        /// <param name="input">Inserted command for pawn's move.</param>
        /// <returns>True if is valid, otherwise - false.</returns>
        public static bool IsValidPawnMove(string input)
        {
            string validInput = input.ToUpper();
            var regex = new Regex(GameConstants.RegexPawnPattern);

            if (regex.IsMatch(validInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Indicates if the king's move is valid.
        /// </summary>
        /// <param name="input">Inserted command for king's move.</param>
        /// <returns>True if is valid, otherwise - false.</returns>
        public static bool IsValidKingMove(string input)
        {
            string validInput = input.ToUpper();
            var regex = new Regex(GameConstants.RegexKingPattern);

            if (regex.IsMatch(validInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Null object pattern. Provides throwing null refecence exception if the given object is null.
        /// </summary>
        /// <param name="obj">Object to be checked is null or not.</param>
        public static void CheckIfObjectIsNull(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException(MessageConstants.NullFigureErrorMessage);
            }
        }

        /// <summary>
        /// You don't say
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool IsValidCommand(string command)
        {
            return true;
        }

        /// <summary>
        /// Method validates if the given position exists on the board of the game.
        /// </summary>
        /// <param name="position">The position to be checked.</param>
        /// <returns>Returns true when the position is on the board. Otherwise - false.</returns>
        public static bool IsPositionOnTheBoard(IPosition position)
        {
            bool leftBoundariesOfRow = position.Row >= GameConstants.BoardEdges[0].Row;
            bool rightBoundariesOfRow = position.Row <= GameConstants.BoardEdges[3].Row;
            bool isRowOnTheBoard = leftBoundariesOfRow && rightBoundariesOfRow;

            bool leftBoundariesOfCol = position.Col >= GameConstants.BoardEdges[0].Col;
            bool rightBoundariesOfCol = position.Col <= GameConstants.BoardEdges[3].Col;
            bool isColOnTheBoard = leftBoundariesOfCol && rightBoundariesOfCol;

            bool isPositionOnTheBoard = isRowOnTheBoard && isColOnTheBoard;
            return isPositionOnTheBoard;
        }
        
        /// <summary>
        /// Feature: Implementation of the Decorator pattern for the figures and they can move or not. The method checks the given figure is moveable.
        /// </summary>
        /// <returns>True.</returns>
        internal static bool CanMove()
        {
            return true;
        }
    }
}
