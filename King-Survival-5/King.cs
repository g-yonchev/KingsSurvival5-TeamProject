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
            bool leftBoundariesOfRow = row >= BoardEdges[0, 0];
            bool rightBoundariesOfRow = row <= BoardEdges[3, 0];
            bool isRowOnTheBoard = (leftBoundariesOfRow) && rightBoundariesOfRow;

            int col = positionCoodinates[1];
            bool leftBoundariesOfCol = col >= BoardEdges[0, 1];
            bool rightBoundariesOfCol = col <= BoardEdges[3, 1];
            bool isColOnTheBoard = leftBoundariesOfCol && rightBoundariesOfCol;

            bool isPositionOnTheBoard = isRowOnTheBoard && isColOnTheBoard;
            return isPositionOnTheBoard;
        }

        static void ColorBoard(ConsoleColor bgColor, ConsoleColor fgColor)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
        }

        static void PrintBoard()
        {
            Console.WriteLine();
            for (int row = 0; row < Field.GetLength(0); row++)
            {
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = IsPositionOnTheBoard(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                ConsoleColor bgColor = ConsoleColor.Green;
                                SetConsoleColor(bgColor, row, col);

                            }
                            else if (col % 2 == 0)
                            {
                                ConsoleColor bgColor = ConsoleColor.Blue;
                                SetConsoleColor(bgColor, row, col);
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(Field[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            ConsoleColor bgColor = ConsoleColor.Blue;
                            SetConsoleColor(bgColor, row, col);
                        }
                        else if (col % 2 == 0)
                        {
                            ConsoleColor bgColor = ConsoleColor.Green;
                                SetConsoleColor(bgColor, row, col);
                        }

                        else if (col % 2 != 0)
                        {
                            Console.Write(Field[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(Field[row, col]);
                    }

                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        private static void SetConsoleColor(ConsoleColor bgColor, int row, int col)
        {
            ConsoleColor fgColor = ConsoleColor.Black;
            ColorBoard(bgColor, fgColor);
            Console.Write(Field[row, col]);
            Console.ResetColor();
        }

        static void Start(int moveCounter)
        {
            if (!GameOver)
            {
                PrintBoard();

                bool isKingTurn = moveCounter % 2 == 0;
                if (isKingTurn)
                {
                    ProcessKingSide();
                }
                else
                {
                    ProcessPawnSide();
                }
            }
            else
            {
                Console.WriteLine(Constants.FinishGameMessage);
                return;
            }

        }

        static bool IsValidCommand(string checkedString)
        {
            if (Counter % 2 == 0)
            {
                bool isValidCommand = false;
                foreach (var validKingMove in KingPosibleDirections)
                {
                    if (checkedString == validKingMove)
                    {
                        isValidCommand = true;
                        break;
                    }
                }

                if (!isValidCommand)
                {
                    PrintMessage(ConsoleColor.Red, Constants.InvalidCommandMessage);
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
                    PrintMessage(ConsoleColor.Red, Constants.InvalidCommandMessage);
                    return false;
                }
            }
        }

        private static void PrintMessage(ConsoleColor color, string message)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static bool IsValidPawnMove(string move)
        {
            bool isValidCommand = false;
            foreach (var validPawnMove in PawnAPosibleDirections)
            {
                if (move.Substring(1) == validPawnMove.Substring(1))
                {
                    isValidCommand = true;
                    break;
                }
            }

            if (!isValidCommand)
            {
                PrintMessage(ConsoleColor.Red, Constants.InvalidCommandMessage);
            }

            return isValidCommand;
        }

        static void PawnDirection(char pawn, char direction, int pawnNumber)
        {
            var oldCoordinates = new int[2];
            oldCoordinates[0] = PawnPositions[pawnNumber, 0];
            oldCoordinates[1] = PawnPositions[pawnNumber, 1];

            var coords = new int[2];
            coords = CheckNextPownPosition(oldCoordinates, direction, pawn);

            if (coords != null)
            {
                PawnPositions[pawnNumber, 0] = coords[0];
                PawnPositions[pawnNumber, 1] = coords[1];
            }
        }

        static void KingDirection(char upDownDirection, char leftRightDirection)
        {
            var oldCoordinates = new int[2];
            oldCoordinates[0] = KingPosition[0];
            oldCoordinates[1] = KingPosition[1];
            var coords = new int[2];
            coords = CheckNextKingPosition(oldCoordinates, upDownDirection, leftRightDirection);
            if (coords != null)
            {
                KingPosition[0] = coords[0];
                KingPosition[1] = coords[1];
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
                        Console.WriteLine(Constants.ErrorMessage);
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
                PrintMessage(ConsoleColor.DarkGreen, Constants.KingTurnMessage);
               
                string input = Console.ReadLine();
                if (input != string.Empty)
                {
                    input = input.ToUpper();
                    isExecuted = CommandCheck(input);
                }
                else
                {
                    isExecuted = false;

                    PrintMessage(ConsoleColor.DarkRed, Constants.EmptyStringMessage);
                }
            }
            Start(Counter);
        }

        static void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                PrintMessage(ConsoleColor.Blue, Constants.PawnTurnMassage);

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
                    
                    PrintMessage(ConsoleColor.DarkRed, Constants.EmptyStringMessage);
                }
            }
            Start(Counter);
        }

        static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine(Constants.KingVictoryMessage, Counter / 2);
                GameOver = true;
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
                    Console.WriteLine(Constants.ErrorMessage);
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
            var newCoords = new int[2];
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];

                bool isEmptyCurrentCell = Field[newCoords[0], newCoords[1]] == ' ';
                if (IsPositionOnTheBoard(newCoords) && isEmptyCurrentCell)
                {
                    MoveFigure(currentCoordinates, newCoords);

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
                            Console.WriteLine(Constants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        GameOver = true;
                        Console.WriteLine(Constants.KingVictoryMessage, Counter / 2);
                        GameOver = true;
                        return null;
                    }

                    PrintMessage(ConsoleColor.DarkYellow, Constants.WrongDirectionMessage);

                    return null;
                }
            }
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];

                bool isEmptyCurrentCell = Field[newCoords[0], newCoords[1]] == ' ';
                if (IsPositionOnTheBoard(newCoords) && isEmptyCurrentCell)
                {
                    MoveFigure(currentCoordinates, newCoords);

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
                            Console.WriteLine(Constants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        GameOver = true;
                        Console.WriteLine(Constants.KingVictoryMessage, Counter / 2);
                        GameOver = true;
                        return null;
                    }

                    PrintMessage(ConsoleColor.DarkYellow, Constants.WrongDirectionMessage);

                    return null;
                }
            }

        }

        static void MoveFigure(int[] currentCoordinates, int[] newCoords)
        {
            char currentPos = Field[currentCoordinates[0], currentCoordinates[1]];
            Field[currentCoordinates[0], currentCoordinates[1]] = ' ';
            Field[newCoords[0], newCoords[1]] = currentPos;
        }

        static int[] CheckNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] displasmentUpLeft = { -1, -2 };
            int[] displasmentUpRight = { -1, 2 };
            var newCoords = new int[2];

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpLeft[1];

                    bool isEmptyCurrentCell = Field[newCoords[0], newCoords[1]] == ' ';
                    if (IsPositionOnTheBoard(newCoords) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoords);

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
                        bool allAreFalse = KingExistingMovesMethod(0);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMessage(ConsoleColor.DarkYellow, Constants.WrongDirectionMessage);

                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];

                    bool isEmptyCurrentCell = Field[newCoords[0], newCoords[1]] == ' ';
                    if (IsPositionOnTheBoard(newCoords) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoords);

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
                        bool allAreFalse = KingExistingMovesMethod(1);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMessage(ConsoleColor.DarkYellow, Constants.WrongDirectionMessage);

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

                    bool isEmptyCurrentCell = Field[newCoords[0], newCoords[1]] == ' ';
                    if (IsPositionOnTheBoard(newCoords) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoords);

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
                        bool allAreFalse = KingExistingMovesMethod(2);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMessage(ConsoleColor.DarkYellow, Constants.WrongDirectionMessage);

                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];

                    bool isEmptyCurrentCell = Field[newCoords[0], newCoords[1]] == ' ';
                    if (IsPositionOnTheBoard(newCoords) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoords);

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
                        bool allAreFalse = KingExistingMovesMethod(3);
                        if (allAreFalse)
                        {
                            GameOver = true;
                            CommandPrintKingLosing();
                            return null;
                        }

                        PrintMessage(ConsoleColor.DarkYellow, Constants.WrongDirectionMessage);

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

        //static void CommandPrintWrongDirection()
        //{
        //    Console.BackgroundColor = ConsoleColor.DarkYellow;
        //    Console.WriteLine(Constants.WRONG_DIRECTION_MESSAGE);
        //    Console.ResetColor();
        //}

        static void CommandPrintKingLosing()
        {
            Console.WriteLine(Constants.KingLostMessage, Counter / 2);
        }

        static void Main()
        {
            Start(Counter);
            Console.WriteLine(Constants.GoodbyeMessage);
            Console.ReadLine();
        }
    }
}