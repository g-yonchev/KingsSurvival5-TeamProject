namespace KingSurvival
{
    using Commons;
    using Contracts;
    using Models;
    using System;
    using System.Text.RegularExpressions;

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

        public static IPosition[] BoardEdgesGetter
        {
            get
            {
                return BoardEdges;
            }
        }

        protected static IPosition KingPosition = new Position(9, 10);

        protected static bool[,] PawnExistingMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        public static bool[,] PawnExistingMovesGetter
        {
            get
            {
                return PawnExistingMoves;
            }
            set
            {
                PawnExistingMoves = value;
            }
        }

        protected static string[] KingPossibleDirections = { "KUL", "KUR", "KDL", "KDR" };

        protected static bool[] KingExistingMoves = { true, true, true, true };
        public static bool[] KingExistingMovesGetter
        {
            get
            {
                return KingExistingMoves;
            }
            set
            {
                KingExistingMoves = value;
            }
        }

        protected static string[] PawnAPossibleDirections = { "ADL", "ADR" };

        protected static string[] PawnBPossibleDirections = { "BDL", "BDR" };

        protected static string[] PawnCPossibleDirections = { "CDL", "CDR" };

        protected static string[] PawnDPossibleDirections = { "DDL", "DDR" };

        //protected static int Counter = 0;

        public static int Counter { get; set; }

        public static string[] KingPossibleDirectionsGetter
        {
            get
            {
                return KingPossibleDirections;
            }
        }

        protected static bool GameOver = false;
        public static bool GameOverGetter {
            get
            {
                return GameOver;
            }
            set
            {
                GameOver = value;
            }
        }
        protected static IPosition[] PawnPositions = 
        {
            new Position(2, 4), new Position(2, 8), new Position(2, 12), new Position(2, 16)
        };

        // RULE CHECKER:   <<< BaseGame is the class that sets the rules and CHECKS for them.
        // So all kinds of checks should be here. All the moves the player executes should be in 
        // KingSurvivalGame
        

        protected static void SetConsoleColor(ConsoleColor bgColor, int row, int col)
        {
            //ConsoleColor fgColor = ConsoleColor.Black;
            //ColorBoard(bgColor, fgColor);
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(GetField[row, col]);
            Console.ResetColor();
        }

        public static void CommandPrintKingLosing()
        {
            Console.WriteLine(MessageConstants.KingLostMessage, Counter / 2);
        }

        

        

        

        public static void SwitchCurrentPawnExistingMoves(char currentPawn)
        {
            switch (currentPawn)
            {
                case 'A':
                    PawnExistingMoves[0, 0] = true;
                    PawnExistingMoves[0, 1] = true;
                    break;
                case 'B':
                    PawnExistingMoves[1, 0] = true;
                    PawnExistingMoves[1, 1] = true;
                    break;
                case 'C':
                    PawnExistingMoves[2, 0] = true;
                    PawnExistingMoves[2, 1] = true;
                    break;
                case 'D':
                    PawnExistingMoves[3, 0] = true;
                    PawnExistingMoves[3, 1] = true;
                    break;
                default:
                    Console.WriteLine(MessageConstants.ErrorMessage);
                    break;
            }
        }

        

        public static void PawnDirection(char pawn, char direction, int pawnNumber)
        {
            var oldCoordinates = PawnPositions[pawnNumber];

            var coords = Checker.CheckNextPawnPosition(oldCoordinates, direction, pawn);

            if (coords != null)
            {
                PawnPositions[pawnNumber] = coords;
            }
        }

        public static void KingDirection(char upDownDirection, char leftRightDirection)
        {
            var oldCoordinates = new Position(KingPosition.Row, KingPosition.Col);

            var coords = Checker.CheckNextKingPosition(oldCoordinates, upDownDirection, leftRightDirection);
            if (coords != null)
            {
                KingPosition = coords;
            }
        }

        

        public static bool KingExistingMovesMethod(int someMagicNumber)
        {
            KingExistingMoves[someMagicNumber] = false;
            bool allAreFalse = true;
            for (int i = 0; i < 4; i++)
            {
                if (KingExistingMoves[i])
                {
                    allAreFalse = false;
                }
            }

            return allAreFalse;
        }

        

        

    }
}
