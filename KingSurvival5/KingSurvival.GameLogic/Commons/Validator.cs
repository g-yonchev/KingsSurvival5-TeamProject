namespace KingSurvival.GameLogic.Commons
{
    using System;
    using System.Text.RegularExpressions;

    using Contracts;

    public class Validator
    {
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

        public static void CheckIfObjectIsNull(object obj, string errorMessage = MessageConstants.EmptyString)
        {
            if (obj == null)
            {
                throw new NullReferenceException(MessageConstants.NullFigureErrorMessage);
            }
        }

        public static bool IsValidCommand(string command)
        {
            return true;
        }

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

        internal static bool CanMove()
        {
            return true;
        }
    }
}
