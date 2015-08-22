﻿namespace King
{
    public class BaseGame
    {
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

        protected static int[,] BoardEdges = 
        {
            { 2, 4 }, { 2, 18 }, { 9, 4 }, { 9, 18 }
        };

        protected static int[] KingPosition = { 9, 10 };

        protected static bool[,] PawnExistingMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        protected static string[] KingPosibleDirections = { "KUL", "KUR", "KDL", "KDR" };
        protected static bool[] KingExistingMoves = { true, true, true, true };

        protected static string[] PawnAPosibleDirections = { "ADL", "ADR" };

        protected static string[] PawnBPosibleDirections = { "BDL", "BDR" };

        protected static string[] PawnCPosibleDirections = { "CDL", "CDR" };

        protected static string[] PawnDPosibleDirections = { "DDL", "DDR" };

        protected static int Counter = 0;

        protected static bool GameOver = false;
        protected static int[,] PawnPositions = 
        {
            { 2, 4 }, { 2, 8 }, { 2, 12 }, { 2, 16 }
        };
    }
}
