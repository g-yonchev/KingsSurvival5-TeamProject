namespace KingSurvival.ConsoleClient
{
    using System;
    using KingSurvival.GameLogic.Contracts;
    using KingSurvival.GameLogic.Models;

    public class BaseGame
    {
        private static readonly char[,] Field =
        {
            { 'U', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'U', 'R' },
            { ' ', ' ', ' ', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', ' ', ' ', ' ' },
            { '0', ' ', '|', ' ', 'A', ' ', ' ', ' ', 'B', ' ', ' ', ' ', 'C', ' ', ' ', ' ', 'D', ' ', ' ', ' ', '|', ' ', '0' },
            { '1', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '1' },
            { '2', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2' },
            { '3', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '3' },
            { '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '4' },
            { '5', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '5' },
            { '6', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '6' },
            { '7', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '7' },
            { ' ', ' ', '|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|', ' ', ' ' },
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' },
        };

        protected static IPosition KingPosition = new Position(9, 10);

        protected static readonly bool[,] PawnExistingMoves =
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        protected readonly static string[] KingPossibleDirections = { "KUL", "KUR", "KDL", "KDR" };
        protected readonly static bool[] KingExistingMoves = { true, true, true, true };

        protected readonly static string[] PawnAPossibleDirections = { "ADL", "ADR" };

        protected readonly static string[] PawnBPossibleDirections = { "BDL", "BDR" };

        protected readonly static string[] PawnCPossibleDirections = { "CDL", "CDR" };

        protected readonly static string[] PawnDPossibleDirections = { "DDL", "DDR" };

        public static int Counter { get; set; }

        protected static bool GameOver = false;

        public static char[,] GetField
        {
            get
            {
                return Field;
            }
        }

        protected static IPosition[] boardEdges =
       {
            new Position(2, 4), new Position(2, 18), new Position(9, 4), new Position(9, 18)
        };

        protected static IPosition[] PawnPositions =
        {
            new Position(2, 4), new Position(2, 8), new Position(2, 12), new Position(2, 16)
        };

        // RULE CHECKER:   <<< BaseGame is the class that sets the rules and CHECKS for them.
        // So all kinds of checks should be here. All the moves the player executes should be in
        // KingSurvivalGame
        public static bool IsPositionOnTheBoard(IPosition position)
        {
            bool leftBoundariesOfRow = position.Row >= boardEdges[0].Row;
            bool rightBoundariesOfRow = position.Row <= boardEdges[3].Row;
            bool isRowOnTheBoard = (leftBoundariesOfRow) && rightBoundariesOfRow;

            bool leftBoundariesOfCol = position.Col >= boardEdges[0].Col;
            bool rightBoundariesOfCol = position.Col <= boardEdges[3].Col;
            bool isColOnTheBoard = leftBoundariesOfCol && rightBoundariesOfCol;

            bool isPositionOnTheBoard = isRowOnTheBoard && isColOnTheBoard;
            return isPositionOnTheBoard;
        }

        protected static void SetConsoleColor(ConsoleColor bgColor, int row, int col)
        {
            //ConsoleColor fgColor = ConsoleColor.Black;
            //ColorBoard(bgColor, fgColor);
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(GetField[row, col]);
            Console.ResetColor();
        }
    }
}