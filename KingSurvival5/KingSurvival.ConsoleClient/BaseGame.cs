namespace KingSurvival.ConsoleClient
{
    using System;
    using GameLogic.Commons;
    using GameLogic.Contracts;
    using GameLogic.Models;

    public class BaseGame
    {
        public static readonly IPosition[] PawnPositions =
       {
            new Position(2, 4), new Position(2, 8), new Position(2, 12), new Position(2, 16)
        };

        internal static IPosition KingPosition = new Position(9, 10);  // TODO

        public static char[,] GetField
        {
            get
            {
                return GameConstants.Field;
            }
        }

        public static int Counter { get; set; }

        protected static void SetConsoleColor(ConsoleColor backgroundColor, int row, int col)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(GetField[row, col]);
            Console.ResetColor();
        }
    }
}