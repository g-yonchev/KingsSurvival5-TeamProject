namespace KingSurvivalGame
{
    using System;
    using King;
    using King.Commons;

    public class KingSurvivalGame : BaseGame
    {
        static bool IsPositionOnTheBoard(int[] positionCoodinates)
        {
            int row = positionCoodinates[0];
            bool isRowOnTheBoard = (row >= boardEdges[0, 0]) && (row <= boardEdges[3, 0]);

            int col = positionCoodinates[1];
            bool isColOnTheBoard = (col >= boardEdges[0, 1]) && (col <= boardEdges[3, 1]);

            return isRowOnTheBoard && isColOnTheBoard;
        }

        static void ColorBoard(ConsoleColor bgColor, ConsoleColor fgColor)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
        }

        static void PrintBoard()
        {
            Console.WriteLine();
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = IsPositionOnTheBoard(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                var bgColor = ConsoleColor.Green;
                                SetConsoleColor(bgColor, row, col);

                            }
                            else if (col % 2 == 0)
                            {
                                var bgColor = ConsoleColor.Blue;
                                SetConsoleColor(bgColor, row, col);
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(field[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            var bgColor = ConsoleColor.Blue;
                            SetConsoleColor(bgColor, row, col);
                        }
                        else if (col % 2 == 0)
                        {
                            var bgColor = ConsoleColor.Green;
                                SetConsoleColor(bgColor, row, col);
                        }

                        else if (col % 2 != 0)
                        {
                            Console.Write(field[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(field[row, col]);
                    }

                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        private static void SetConsoleColor(ConsoleColor bgColor, int row, int col)
        {
            var fgColor = ConsoleColor.Black;
            ColorBoard(bgColor, fgColor);
            Console.Write(field[row, col]);
            Console.ResetColor();
        }

        static void Start(int moveCounter)
        {
            if (gameOver)
            {
                Console.WriteLine(Constants.FINISH_GAME_MESSAGE);
                return;
            }
            else
            {
                PrintBoard();
                if (moveCounter % 2 == 0)
                {
                    ProcessKingSide();
                }
                else
                {
                    ProcessPawnSide();
                }
            }

        }

        static bool IsValidCommand(string checkedString)
        {
            if (Counter % 2 == 0)
            {
                bool isValidCommand = false;
                foreach (var validKingMove in ValidKingInputs)
                {
                    if (checkedString == validKingMove)
                    {
                        isValidCommand = true;
                        break;
                    }
                }

                if (!isValidCommand)
                {
                    PrintMassage(ConsoleColor.Red, Constants.INVALID_COMMAND_MESSAGE);
                }

                return isValidCommand;
            }
            else
            {
                char startLetter = checkedString[0];
                if ((int)startLetter >= (int)'A' && (int)startLetter <= (int)'D')
                {
                    return IsValidPawnMove(checkedString);
                }
                else
                {
                    PrintMassage(ConsoleColor.Red, Constants.INVALID_COMMAND_MESSAGE);
                    return false;
                }
            }
        }

        private static void PrintMassage(ConsoleColor color, string massage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(massage);
            Console.ResetColor();
        }

        private static bool IsValidPawnMove(string move)
        {
            bool isValidCommand = false;
            foreach (var validPawnMove in A)
            {
                if (move.Substring(1) == validPawnMove.Substring(1))
                {
                    isValidCommand = true;
                    break;
                }
            }

            if (!isValidCommand)
            {
                PrintMassage(ConsoleColor.Red, Constants.INVALID_COMMAND_MESSAGE);
            }

            return isValidCommand;
        }

        static void PawnDirection(char pawn, char direction, int pawnNumber)
        {
            int[] oldCoordinates = new int[2];
            oldCoordinates[0] = pawnPositions[pawnNumber, 0];
            oldCoordinates[1] = pawnPositions[pawnNumber, 1];

            int[] coords = new int[2];
            coords = CheckNextPownPosition(oldCoordinates, direction, pawn);

            if (coords != null)
            {
                pawnPositions[pawnNumber, 0] = coords[0];
                pawnPositions[pawnNumber, 1] = coords[1];
            }
        }

        static void KingDirection(char upDownDirction, char leftRightDirection)
        {
            int[] oldCoordinates = new int[2];
            oldCoordinates[0] = kingPosition[0];
            oldCoordinates[1] = kingPosition[1];
            int[] coords = new int[2];
            coords = CheckNextKingPosition(oldCoordinates, upDownDirction, leftRightDirection);
            if (coords != null)
            {
                kingPosition[0] = coords[0];
                kingPosition[1] = coords[1];
            }
        }

        static bool CommandCheck(string checkedInput)
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
                        Console.WriteLine(Constants.ERROR_MESSAGE);
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        static void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                PrintMassage(ConsoleColor.DarkGreen, Constants.KING_TURN_MESSAGE);
               
                string input = Console.ReadLine();
                if (input != string.Empty)
                {
                    input = input.ToUpper();
                    isExecuted = CommandCheck(input);
                }
                else
                {
                    isExecuted = false;

                    PrintMassage(ConsoleColor.DarkRed, Constants.EMPTY_STRING_MESSAGE);
                }
            }
            Start(Counter);
        }

        static void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                PrintMassage(ConsoleColor.Blue, Constants.PAWN_TURN_MASSAGE);

                string input = Console.ReadLine();
                //input = input.Trim();
                if (input != string.Empty)//"/n")
                {
                    // Console.WriteLine(input);
                    input = input.ToUpper();
                    isExecuted = CommandCheck(input);
                }
                else
                {
                    isExecuted = false;
                    
                    PrintMassage(ConsoleColor.DarkRed, Constants.EMPTY_STRING_MESSAGE);
                }
            }
            Start(Counter);
        }

        static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine(Constants.KING_VICTORY_MESSAGE, Counter / 2);
                gameOver = true;
            }
        }

        static void SwitchCurrentPawnExistingMoves(char currentPawn)
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
                    Console.WriteLine(Constants.ERROR_MESSAGE);
                    break;
            }
        }

        static bool CheckingAllPawnMoves()
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

        static int[] CheckNextPownPosition(int[] currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                if (IsPositionOnTheBoard(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    SetMovedFigure(currentCoordinates, newCoords);

                    Counter++;

                    SwitchCurrentPawnExistingMoves(currentPawn);

                    return newCoords;
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
                            Console.WriteLine(Constants.ERROR_MESSAGE);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        gameOver = true;
                        Console.WriteLine(Constants.KING_VICTORY_MESSAGE, Counter / 2);
                        gameOver = true;
                        return null;
                    }

                    PrintMassage(ConsoleColor.DarkYellow, Constants.WRONG_DIRECTION_MESSAGE);

                    return null;
                }
            }
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                if (IsPositionOnTheBoard(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    SetMovedFigure(currentCoordinates, newCoords);

                    Counter++;


                    SwitchCurrentPawnExistingMoves(currentPawn);

                    return newCoords;
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
                            Console.WriteLine(Constants.ERROR_MESSAGE);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        gameOver = true;
                        Console.WriteLine(Constants.KING_VICTORY_MESSAGE, Counter / 2);
                        gameOver = true;
                        return null;
                    }

                    PrintMassage(ConsoleColor.DarkYellow, Constants.WRONG_DIRECTION_MESSAGE);

                    return null;
                }
            }

        }

        static void SetMovedFigure(int[] currentCoordinates, int[] newCoords)
        {
            char sign = field[currentCoordinates[0], currentCoordinates[1]];
            field[currentCoordinates[0], currentCoordinates[1]] = ' ';
            field[newCoords[0], newCoords[1]] = sign;
        }

        static int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] displasmentUpLeft = { -1, -2 };
            int[] displasmentUpRight = { -1, 2 };
            int[] newCoords = new int[2];

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpLeft[1];
                    if (IsPositionOnTheBoard(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        SetMovedFigure(currentCoordinates, newCoords);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        KingExistingMoves[0] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (KingExistingMoves[i])
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMassage(ConsoleColor.DarkYellow, Constants.WRONG_DIRECTION_MESSAGE);

                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];
                    if (IsPositionOnTheBoard(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        SetMovedFigure(currentCoordinates, newCoords);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        KingExistingMoves[1] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (KingExistingMoves[i])
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMassage(ConsoleColor.DarkYellow, Constants.WRONG_DIRECTION_MESSAGE);

                        return null;
                    }
                }
            }
            else
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                    if (IsPositionOnTheBoard(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        SetMovedFigure(currentCoordinates, newCoords);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        KingExistingMoves[2] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (KingExistingMoves[i])
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMassage(ConsoleColor.DarkYellow, Constants.WRONG_DIRECTION_MESSAGE);

                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                    if (IsPositionOnTheBoard(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        SetMovedFigure(currentCoordinates, newCoords);

                        Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            KingExistingMoves[i] = true;
                        }
                        CheckForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        KingExistingMoves[3] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (KingExistingMoves[i])
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMassage(ConsoleColor.DarkYellow, Constants.WRONG_DIRECTION_MESSAGE);

                        return null;
                    }
                }
            }
        }

        //static void CommandPrintWrongDirection()
        //{
        //    Console.BackgroundColor = ConsoleColor.DarkYellow;
        //    Console.WriteLine(Constants.WRONG_DIRECTION_MESSAGE);
        //    Console.ResetColor();
        //}

        static void CommandPrintKingLosing()
        {
            Console.WriteLine(Constants.KING_LOST_MESSAGE, Counter / 2);
        }

        static void Main()
        {
            Start(Counter);
            Console.WriteLine(Constants.GOODBYE_MESSAGE);
            Console.ReadLine();
        }
    }
}