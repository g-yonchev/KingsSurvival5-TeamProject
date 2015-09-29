using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public static class Checker
    {
        // Checks if command is KDR, KUL, etc.
        public static bool CheckIfValidKingDirection(string direction)
        {
            bool isValidDirection = false;

            foreach (var possibleDirection in BaseGame.KingPossibleDirectionsGetter)
            {
                if (direction == possibleDirection)
                {
                    isValidDirection = true;
                    break;
                }
            }

            return isValidDirection;
        }

        public static bool IsPositionOnTheBoard(IPosition Position)
        {
            bool leftBoundariesOfRow = Position.Row >= BaseGame.BoardEdgesGetter[0].Row;
            bool rightBoundariesOfRow = Position.Row <= BaseGame.BoardEdgesGetter[3].Row;
            bool isRowOnTheBoard = (leftBoundariesOfRow) && rightBoundariesOfRow;

            bool leftBoundariesOfCol = Position.Col >= BaseGame.BoardEdgesGetter[0].Col;
            bool rightBoundariesOfCol = Position.Col <= BaseGame.BoardEdgesGetter[3].Col;
            bool isColOnTheBoard = leftBoundariesOfCol && rightBoundariesOfCol;

            bool isPositionOnTheBoard = isRowOnTheBoard && isColOnTheBoard;
            return isPositionOnTheBoard;
        }
    }
}
