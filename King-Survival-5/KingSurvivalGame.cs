namespace KingSurvivalGame
{
    using System;
    using King;
    using King.Commons;
    using System.Text.RegularExpressions;

    // using King.Contracts;

    public class KingSurvivalGame : BaseGame
    {
        ////private IPrinter printer;

        ////public KingSurvivalGame(IPrinter printer)
        ////{
        ////    this.printer = printer;
        ////}

        public static bool IsPositionOnTheBoard(IPosition Position)
        {
            bool leftBoundariesOfRow = Position.Row >= BoardEdges[0].Row;
            bool rightBoundariesOfRow = Position.Row <= BoardEdges[3].Row;
            bool isRowOnTheBoard = (leftBoundariesOfRow) && rightBoundariesOfRow;

            bool leftBoundariesOfCol = Position.Col >= BoardEdges[0].Col;
            bool rightBoundariesOfCol = Position.Col <= BoardEdges[3].Col;
            bool isColOnTheBoard = leftBoundariesOfCol && rightBoundariesOfCol;

            bool isPositionOnTheBoard = isRowOnTheBoard && isColOnTheBoard;
            return isPositionOnTheBoard;
        }

        ////static void ColorBoard(ConsoleColor bgColor, ConsoleColor fgColor)
        ////{
        ////    Console.BackgroundColor = bgColor;
        ////    Console.ForegroundColor = fgColor;
        ////}

        public static void PrintBoard()
        {
            Console.WriteLine();
            for (int row = 0; row < GetField.GetLength(0); row++)
            {
                for (int col = 0; col < GetField.GetLength(1); col++)
                {
                    Position coordinates = new Position(row, col);
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
                                Console.Write(GetField[row, col]);
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
                            Console.Write(GetField[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(GetField[row, col]);
                    }
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        public static void Start(int moveCounter)
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
                Console.WriteLine(MessageConstants.FinishGameMessage);
                return;
            }
        }

        public static bool IsValidCommand(string input)
        {
            if (Counter % 2 == 0)
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

        public static void ProcessKingSide()
        {
            bool shouldAskForInput = true;
            while (shouldAskForInput)
            {
                Printer.PrintMessage(ConsoleColor.DarkGreen, MessageConstants.KingTurnMessage);

                string input = GetInput();
                if (input == string.Empty)
                {
                    Printer.PrintMessage(ConsoleColor.DarkRed, MessageConstants.EmptyStringMessage);
                    continue;
                }

                bool isValidDirection = CheckIfValidKingDirection(input);
                if (!isValidDirection)
                {
                    Printer.PrintMessage(ConsoleColor.Red, MessageConstants.InvalidCommandMessage);
                    continue;
                }

                shouldAskForInput = false;

                // Does a lot of magic. Basically, if the king can move to the new position, it moves. The Counter is updated and
                // it's pawns' turn. If the king can't move to the new position, the Counter is not updated and ProcessKingSide()
                // is called again.
                KingDirection(input[1], input[2]);
            }

            Start(Counter);
        }

        public static void ProcessPawnSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Printer.PrintMessage(ConsoleColor.Blue, MessageConstants.PawnTurnMessage);

                string input = Console.ReadLine();

                // input = input.Trim();
                if (input != string.Empty)//"/n")
                {
                    // Console.WriteLine(input);
                    input = input.ToUpper();
                    isExecuted = CommandCheck(input);
                }
                else
                {
                    isExecuted = false;

                    Printer.PrintMessage(ConsoleColor.DarkRed, MessageConstants.EmptyStringMessage);
                }
            }

            Start(Counter);
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
                if (IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    MoveFigure(currentCoordinates, newCoordinates);

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
                if (IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    MoveFigure(currentCoordinates, newCoordinates);

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

        public static void MoveFigure(IPosition currentCoordinates, IPosition newCoordinates)
        {
            char currentPos = GetField[currentCoordinates.Row, currentCoordinates.Col];
            GetField[currentCoordinates.Row, currentCoordinates.Col] = ' ';
            GetField[newCoordinates.Row, newCoordinates.Col] = currentPos;
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
                    if (IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

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
                    if (IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

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
                    if (IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

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
                    if (IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

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

        ////static void CommandPrintWrongDirection()
        ////{
        ////    Console.BackgroundColor = ConsoleColor.DarkYellow;
        ////    Console.WriteLine(Constants.WRONG_DIRECTION_MESSAGE);
        ////    Console.ResetColor();
        ////}

        public static void CommandPrintKingLosing()
        {
            Console.WriteLine(MessageConstants.KingLostMessage, Counter / 2);
        }

        public static void Main()
        {
            //IPrinter printer = new Printer();
            Start(Counter);
            Console.WriteLine(MessageConstants.GoodbyeMessage);
            Console.ReadLine();
        }

        // Checks if command is KDR, KUL, etc.
        private static bool CheckIfValidKingDirection(string direction)
        {
            bool isValidDirection = false;

            foreach (var possibleDirection in KingPossibleDirections)
            {
                if (direction == possibleDirection)
                {
                    isValidDirection = true;
                    break;
                }
            }

            return isValidDirection;
        }

        // Returns user input after trimming and making it to upper case. Returns empty string if input is only white spaces.
        private static string GetInput()
        {
            string result = string.Empty;

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                return result;
            }
            else
            {
                string inputTrimmed = input.Trim();
                result = inputTrimmed.ToUpper();

                return result;
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
    }
}