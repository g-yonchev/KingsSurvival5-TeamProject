namespace KingSurvival.ConsoleClient
{

    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Contracts;
    using KingSurvival.GameLogic.Models;
    using System;
    using System.Text.RegularExpressions;

    public static class Checker // Checks if the game rules are correctly executed or broken
    {
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

        //Checks if command is ADR, ADL, BDR, etc.
        public static bool CheckIfValidPawnDirection(string direction)
        {
            bool isValidDirection = Validator.IsValidPawnMove(direction);
            return isValidDirection;
        }

        public static bool CommandCheck(string checkedInput)
        {
            bool commandNameIsOK = IsValidCommand(checkedInput);
            if (commandNameIsOK)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':
                        if (checkedInput[2] == 'L')
                        {
                            BaseGame.PawnDirection('A', 'L', 0);
                        }
                        else
                        {
                            BaseGame.PawnDirection('A', 'R', 0);
                        }

                        return true;

                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            BaseGame.PawnDirection('B', 'L', 1);
                        }
                        else
                        {
                            BaseGame.PawnDirection('B', 'R', 1);
                        }

                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            BaseGame.PawnDirection('C', 'L', 2);
                        }
                        else
                        {
                            BaseGame.PawnDirection('C', 'R', 2);
                        }

                        return true;

                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            BaseGame.PawnDirection('D', 'L', 3);
                        }
                        else
                        {
                            BaseGame.PawnDirection('D', 'R', 3);
                        }

                        return true;

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                BaseGame.KingDirection('U', 'L');
                            }
                            else
                            {
                                BaseGame.KingDirection('U', 'R');
                            }
                        }
                        else
                        {
                            if (checkedInput[2] == 'L')
                            {
                                BaseGame.KingDirection('D', 'L');
                            }
                            else
                            {
                                BaseGame.KingDirection('D', 'R');
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

        public static bool IsValidCommand(string input)
        {
            if (BaseGame.Counter % 2 == 0)
            {
                bool isValidCommand = false;

                if (IsValidKingMove(input))
                {
                    isValidCommand = true;
                }
                else
                {
                    Printer.PrintMessage(ConsoleColor.Red, MessageConstants.InvalidCommandMessage);
                }

                return isValidCommand;
            }
            else
            {
                bool isValidCommand = false;

                if (IsValidPawnMove(input))
                {
                    isValidCommand = true;
                }
                else
                {
                    Printer.PrintMessage(ConsoleColor.Red, MessageConstants.InvalidCommandMessage);
                }

                return isValidCommand;
            }

        }

        private static bool IsValidPawnMove(string input)
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

        private static bool IsValidKingMove(string input)
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

        public static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(MessageConstants.KingVictoryMessage, BaseGame.Counter / 2);
                BaseGame.GameOverGetter = true;
            }
        }

        public static bool CheckingAllPawnMoves()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (BaseGame.PawnExistingMovesGetter[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
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

                bool isEmptyCurrentCell = BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    Mover.MoveFigure(currentCoordinates, newCoordinates);

                    BaseGame.Counter++;

                    BaseGame.SwitchCurrentPawnExistingMoves(currentPawn);

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
                            BaseGame.PawnExistingMovesGetter[0, 0] = false;
                            break;
                        case 'B':
                            BaseGame.PawnExistingMovesGetter[1, 0] = false;
                            break;
                        case 'C':
                            BaseGame.PawnExistingMovesGetter[2, 0] = false;
                            break;
                        case 'D':
                            BaseGame.PawnExistingMovesGetter[3, 0] = false;
                            break;
                        default:
                            Console.WriteLine(MessageConstants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        BaseGame.GameOverGetter = true;
                        Console.WriteLine(MessageConstants.KingVictoryMessage, BaseGame.Counter / 2);
                        BaseGame.GameOverGetter = true;
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

                bool isEmptyCurrentCell = BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    Mover.MoveFigure(currentCoordinates, newCoordinates);

                    BaseGame.Counter++;

                    BaseGame.SwitchCurrentPawnExistingMoves(currentPawn);

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
                            BaseGame.PawnExistingMovesGetter[0, 1] = false;
                            break;
                        case 'B':
                            BaseGame.PawnExistingMovesGetter[1, 1] = false;
                            break;
                        case 'C':
                            BaseGame.PawnExistingMovesGetter[2, 1] = false;
                            break;
                        case 'D':
                            BaseGame.PawnExistingMovesGetter[3, 1] = false;
                            break;
                        default:
                            Console.WriteLine(MessageConstants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        BaseGame.GameOverGetter = true;
                        Console.WriteLine(MessageConstants.KingVictoryMessage, BaseGame.Counter / 2);
                        BaseGame.GameOverGetter = true;
                        return null;
                    }

                    Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                    return null;
                }
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

                    bool isEmptyCurrentCell = BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            BaseGame.KingExistingMovesGetter[i] = true;
                        }

                        Checker.CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = BaseGame.KingExistingMovesMethod(0);
                        if (allAreFalse)
                        {
                            BaseGame.GameOverGetter = true;
                            BaseGame.CommandPrintKingLosing();
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

                    bool isEmptyCurrentCell = BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            BaseGame.KingExistingMovesGetter[i] = true;
                        }

                        Checker.CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = BaseGame.KingExistingMovesMethod(1);
                        if (allAreFalse)
                        {
                            BaseGame.GameOverGetter = true;
                            BaseGame.CommandPrintKingLosing();
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

                    bool isEmptyCurrentCell = BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            BaseGame.KingExistingMovesGetter[i] = true;
                        }

                        Checker.CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = BaseGame.KingExistingMovesMethod(2);
                        if (allAreFalse)
                        {
                            BaseGame.GameOverGetter = true;
                            BaseGame.CommandPrintKingLosing();
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

                    bool isEmptyCurrentCell = BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Checker.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        Mover.MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            BaseGame.KingExistingMovesGetter[i] = true;
                        }

                        Checker.CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = BaseGame.KingExistingMovesMethod(3);
                        if (allAreFalse)
                        {
                            BaseGame.GameOverGetter = true;
                            BaseGame.CommandPrintKingLosing();
                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);

                        return null;
                    }
                }
            }
        }
    }
}
