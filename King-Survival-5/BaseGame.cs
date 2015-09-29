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

        protected static string[] KingPossibleDirections = { "KUL", "KUR", "KDL", "KDR" };

        protected static bool[] KingExistingMoves = { true, true, true, true };

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

        

        public static bool CommandCheck(string checkedInput)
        {
            bool commandNameIsOK = Checker.IsValidCommand(checkedInput);
            if (commandNameIsOK)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        if (checkedInput[2] == 'L')
                        {
                            PawnDirection('A', 'L', 0);
                        }
                        else
                        {
                            PawnDirection('A', 'R', 0);
                        }

                        return true;

                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            PawnDirection('B', 'L', 1);
                        }
                        else
                        {
                            PawnDirection('B', 'R', 1);
                        }

                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            PawnDirection('C', 'L', 2);
                        }
                        else
                        {
                            PawnDirection('C', 'R', 2);
                        }

                        return true;

                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            PawnDirection('D', 'L', 3);
                        }
                        else
                        {
                            PawnDirection('D', 'R', 3);
                        }

                        return true;

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                KingDirection('U', 'L');
                            }
                            else
                            {
                                KingDirection('U', 'R');
                            }
                        }
                        else
                        {
                            if (checkedInput[2] == 'L')
                            {
                                KingDirection('D', 'L');
                            }
                            else
                            {
                                KingDirection('D', 'R');
                            }
                        }

                        return true;
                    default:
                        Console.WriteLine(MessageConstants.ErrorMessage);
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static IPosition CheckNextPawnPosition(IPosition currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displacementDownLeft = { 1, -2 };
            int[] displacementDownRight = { 1, 2 };
            var newCoordinates = new Position();
            if (checkDirection == 'L')
            {
                newCoordinates.Row = currentCoordinates.Row + displacementDownLeft[0];
                newCoordinates.Col = currentCoordinates.Col + displacementDownLeft[1];

                bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    Mover.MoveFigure(currentCoordinates, newCoordinates);

                    Counter++;

                    SwitchCurrentPawnExistingMoves(currentPawn);

                    return newCoordinates;
                }
                else
                {
                    /* switch (currentPawn)
                     {
                         case 'A':
                             pawnExistingMoves[0, 0] = false;
                             break;

                         case 'B':
                             pawnExistingMoves[1, 0] = false;
                             break;
                         case 'C':
                             pawnExistingMoves[2, 0] = false;
                             break;

                         case 'D':
                             pawnExistingMoves[3, 0] = false;
                             break;

                         default:
                             Console.WriteLine("ERROR!");
                             break;
                     }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            PawnExistingMoves[0, 0] = false;
                            break;
                        case 'B':
                            PawnExistingMoves[1, 0] = false;
                            break;
                        case 'C':
                            PawnExistingMoves[2, 0] = false;
                            break;
                        case 'D':
                            PawnExistingMoves[3, 0] = false;
                            break;
                        default:
                            Console.WriteLine(MessageConstants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        GameOver = true;
                        Console.WriteLine(MessageConstants.KingVictoryMessage, Counter / 2);
                        GameOver = true;
                        return null;
                    }

                    Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                    return null;
                }
            }
            else
            {
                newCoordinates.Row = currentCoordinates.Row + displacementDownRight[0];
                newCoordinates.Col = currentCoordinates.Col + displacementDownRight[1];

                bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    Mover.MoveFigure(currentCoordinates, newCoordinates);

                    Counter++;

                    SwitchCurrentPawnExistingMoves(currentPawn);

                    return newCoordinates;
                }
                else
                {
                    /*   switch (currentPawn)
                       {
                           case 'A':
                               pawnExistingMoves[0, 1] = false;
                               break;

                           case 'B':
                               pawnExistingMoves[1, 1] = false;
                               break;
                           case 'C':
                               pawnExistingMoves[2, 1] = false;
                               break;

                           case 'D':
                               pawnExistingMoves[3, 1] = false;
                               break;

                           default:
                               Console.WriteLine("ERROR!");
                               break;
                       }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            PawnExistingMoves[0, 1] = false;
                            break;
                        case 'B':
                            PawnExistingMoves[1, 1] = false;
                            break;
                        case 'C':
                            PawnExistingMoves[2, 1] = false;
                            break;
                        case 'D':
                            PawnExistingMoves[3, 1] = false;
                            break;
                        default:
                            Console.WriteLine(MessageConstants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        GameOver = true;
                        Console.WriteLine(MessageConstants.KingVictoryMessage, Counter / 2);
                        GameOver = true;
                        return null;
                    }

                    Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                    return null;
                }
            }
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

        public static bool CheckingAllPawnMoves()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (PawnExistingMoves[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void PawnDirection(char pawn, char direction, int pawnNumber)
        {
            var oldCoordinates = PawnPositions[pawnNumber];

            var coords = CheckNextPawnPosition(oldCoordinates, direction, pawn);

            if (coords != null)
            {
                PawnPositions[pawnNumber] = coords;
            }
        }

        public static void KingDirection(char upDownDirection, char leftRightDirection)
        {
            var oldCoordinates = new Position(KingPosition.Row, KingPosition.Col);

            var coords = CheckNextKingPosition(oldCoordinates, upDownDirection, leftRightDirection);
            if (coords != null)
            {
                KingPosition = coords;
            }
        }

        public static IPosition CheckNextKingPosition(IPosition currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displacementDownLeft = { 1, -2 };
            int[] displacementDownRight = { 1, 2 };
            int[] displacementUpLeft = { -1, -2 };
            int[] displacementUpRight = { -1, 2 };
            var newCoordinates = new Position();

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    newCoordinates.Row = currentCoordinates.Row + displacementUpLeft[0];
                    newCoordinates.Col = currentCoordinates.Col + displacementUpLeft[1];

                    bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(0);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                        return null;
                    }
                }
                else
                {
                    newCoordinates.Row = currentCoordinates.Row + displacementUpRight[0];
                    newCoordinates.Col = currentCoordinates.Col + displacementUpRight[1];

                    bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(1);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                        return null;
                    }
                }
            }
            else
            {
                if (secondDirection == 'L')
                {
                    newCoordinates.Row = currentCoordinates.Row + displacementDownLeft[0];
                    newCoordinates.Col = currentCoordinates.Col + displacementDownLeft[1];

                    bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(2);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                        return null;
                    }
                }
                else
                {
                    newCoordinates.Row = currentCoordinates.Row + displacementDownRight[0];
                    newCoordinates.Col = currentCoordinates.Col + displacementDownRight[1];

                    bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(3);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                        return null;
                    }
                }
            }
        }

        private static bool KingExistingMovesMethod(int someMagicNumber)
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

        public static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(MessageConstants.KingVictoryMessage, Counter / 2);
                GameOver = true;
            }
        }

        

    }
}
