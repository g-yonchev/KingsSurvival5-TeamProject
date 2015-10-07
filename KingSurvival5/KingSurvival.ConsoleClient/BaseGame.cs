﻿namespace KingSurvival.ConsoleClient
{
    using System;

    using KingSurvival.GameLogic.Contracts;
    using KingSurvival.GameLogic.Models;

    public class BaseGame
    {
        public static char[,] GetField
        {
            get
            {
                return Field;
            }
        }

        protected static char[,] Field = 
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

        protected static IPosition[] BoardEdges = 
        {
            new Position(2, 4), new Position(2, 18), new Position(9, 4), new Position(9, 18)
        };

        protected static IPosition KingPosition = new Position(9, 10);

        protected static bool[,] PawnExistingMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        protected static string[] KingPossibleDirections = { "KUL", "KUR", "KDL", "KDR" };
        protected static bool[] KingExistingMoves = { true, true, true, true };

        protected static string[] PawnAPossibleDirections = { "ADL", "ADR" };

        protected static string[] PawnBPossibleDirections = { "BDL", "BDR" };

        protected static string[] PawnCPossibleDirections = { "CDL", "CDR" };
         
        protected static string[] PawnDPossibleDirections = { "DDL", "DDR" };

        //protected static int Counter = 0;

        public static int Counter { get; set; }

        protected static bool GameOver = false;
        protected static IPosition[] PawnPositions = 
        {
            new Position(2, 4), new Position(2, 8), new Position(2, 12), new Position(2, 16)
        };

        // RULE CHECKER:   <<< BaseGame is the class that sets the rules and CHECKS for them.
        // So all kinds of checks should be here. All the moves the player executes should be in 
        // KingSurvivalGame
        protected static bool IsPositionOnTheBoard(IPosition position)
        {
            bool leftBoundariesOfRow = position.Row >= BoardEdges[0].Row;
            bool rightBoundariesOfRow = position.Row <= BoardEdges[3].Row;
            bool isRowOnTheBoard = (leftBoundariesOfRow) && rightBoundariesOfRow;

            bool leftBoundariesOfCol = position.Col >= BoardEdges[0].Col;
            bool rightBoundariesOfCol = position.Col <= BoardEdges[3].Col;
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
