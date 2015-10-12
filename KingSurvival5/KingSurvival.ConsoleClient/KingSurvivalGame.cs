namespace KingSurvival.ConsoleClient
{
    using System;
    using System.Threading;
    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Contracts;
    using KingSurvival.GameLogic.Models;

    public class KingSurvivalGame : BaseGame
    {
        private static bool gameOver = false;  // to move someware else 

        public static void PrintBoard()
        {
            Console.WriteLine();
            for (int row = 0; row < GetField.GetLength(0); row++)
            {
                for (int col = 0; col < GetField.GetLength(1); col++)
                {
                    Position coordinates = new Position(row, col);
                    bool isCellIn = Validator.IsPositionOnTheBoard(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                ConsoleColor backgroundColor = ConsoleColor.Green;
                                BaseGame.SetConsoleColor(backgroundColor, row, col);
                            }
                            else if (col % 2 == 0)
                            {
                                ConsoleColor backgroundColor = ConsoleColor.Blue;
                                BaseGame.SetConsoleColor(backgroundColor, row, col);
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(BaseGame.GetField[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            ConsoleColor backgroundColor = ConsoleColor.Blue;
                            BaseGame.SetConsoleColor(backgroundColor, row, col);
                        }
                        else if (col % 2 == 0)
                        {
                            ConsoleColor backgroundColor = ConsoleColor.Green;
                            BaseGame.SetConsoleColor(backgroundColor, row, col);
                        }
                        else if (col % 2 != 0)
                        {
                            Console.Write(BaseGame.GetField[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(BaseGame.GetField[row, col]);
                    }
                }

                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        public static void Start(int moveCounter)
        {
            if (!gameOver)
            {
                Console.Clear();
                PrintBoard();

                bool isKingTurn = moveCounter % 2 == 0;
                if (isKingTurn)
                {
                    ProcessKingTurn();
                }
                else
                {
                    ProcessPawnTurn();
                }
            }
            else
            {
                Console.WriteLine(MessageConstants.FinishGameMessage);
                Thread.Sleep(400);
                return;
            }
        }

        public static void PawnDirection(char pawn, char direction, int pawnNumber)
        {
            var oldCoordinates = PawnPositions[pawnNumber];

            var coords = CheckNextPawnPosition(oldCoordinates, direction, pawn);

            if (coords != null)
            {
                BaseGame.PawnPositions[pawnNumber] = coords;
            }
        }

        public static void KingDirection(char downUpDirection, char leftRightDirection)
        {
            var oldCoordinates = new Position(KingPosition.Row, KingPosition.Col);

            var coords = CheckNextKingPosition(oldCoordinates, downUpDirection, leftRightDirection);
            if (coords != null)
            {
                BaseGame.KingPosition = coords;
            }
        }

        public static void ProcessKingTurn()
        {
            bool shouldAskForInput = true;
            while (shouldAskForInput)
            {
                Printer.PrintMessage(ConsoleColor.DarkGreen, MessageConstants.KingTurnMessage);

                string input = GetInput();
                if (input == string.Empty)
                {
                    Printer.PrintMessage(ConsoleColor.DarkRed, MessageConstants.EmptyStringMessage);
                    Thread.Sleep(400);
                    continue;
                }

                bool isValidDirection = CheckIfValidKingDirection(input);
                if (!isValidDirection)
                {
                    Printer.PrintMessage(ConsoleColor.Red, MessageConstants.InvalidCommandMessage);
                    Thread.Sleep(400);
                    continue;
                }

                shouldAskForInput = false;

                // Does a lot of magic. Basically, if the king can move to the new position, it moves. The Counter is updated and
                // it's pawns' turn. If the king can't move to the new position, the Counter is not updated and ProcessKingSide()
                // is called again.
                KingDirection(input[1], input[2]);
            }

            Start(BaseGame.Counter);
        }

        public static void ProcessPawnTurn()
        {
            bool shouldAskForInput = true;
            while (shouldAskForInput)
            {
                Printer.PrintMessage(ConsoleColor.Blue, MessageConstants.PawnTurnMessage);

                string input = GetInput();
                if (input == string.Empty)
                {
                    Printer.PrintMessage(ConsoleColor.DarkRed, MessageConstants.EmptyStringMessage);
                    Thread.Sleep(400);
                    continue;
                }

                bool isValidDirection = CheckIfValidPawnDirection(input);
                if (!isValidDirection)
                {
                    Printer.PrintMessage(ConsoleColor.Red, MessageConstants.InvalidCommandMessage);
                    Thread.Sleep(400);
                    continue;
                }

                shouldAskForInput = false;

                // I suppose it works in a way similar to KingDirection()
                char pawnName = input[0];
                char directionLeftRight = input[2];
                int pawnNumber = pawnName - 65;
                PawnDirection(pawnName, directionLeftRight, pawnNumber);
            }

            Start(BaseGame.Counter);
        }

        public static void CheckForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(MessageConstants.KingVictoryMessage, BaseGame.Counter / 2);
                gameOver = true;
            }
        }

        public static void SwitchCurrentPawnExistingMoves(char currentPawn)
        {
            switch (currentPawn)
            {
                case 'A':
                    GameConstants.PawnExistingMoves[0, 0] = true;
                    GameConstants.PawnExistingMoves[0, 1] = true;
                    break;

                case 'B':
                    GameConstants.PawnExistingMoves[1, 0] = true;
                    GameConstants.PawnExistingMoves[1, 1] = true;
                    break;

                case 'C':
                    GameConstants.PawnExistingMoves[2, 0] = true;
                    GameConstants.PawnExistingMoves[2, 1] = true;
                    break;

                case 'D':
                    GameConstants.PawnExistingMoves[3, 0] = true;
                    GameConstants.PawnExistingMoves[3, 1] = true;
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
                    if (GameConstants.PawnExistingMoves[i, j])
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
                if (Validator.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    MoveFigure(currentCoordinates, newCoordinates);

                    BaseGame.Counter++;

                    SwitchCurrentPawnExistingMoves(currentPawn);

                    return newCoordinates;
                }
                else
                {
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            GameConstants.PawnExistingMoves[0, 0] = false;
                            break;

                        case 'B':
                            GameConstants.PawnExistingMoves[1, 0] = false;
                            break;

                        case 'C':
                            GameConstants.PawnExistingMoves[2, 0] = false;
                            break;

                        case 'D':
                            GameConstants.PawnExistingMoves[3, 0] = false;
                            break;

                        default:
                            Console.WriteLine(MessageConstants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        gameOver = true;
                        Console.WriteLine(MessageConstants.KingVictoryMessage, BaseGame.Counter / 2);
                        gameOver = true;
                        return null;
                    }

                    Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);
                    Thread.Sleep(400);
                    return null;
                }
            }
            else
            {
                newCoordinates.Row = currentCoordinates.Row + displacementDownRight[0];
                newCoordinates.Col = currentCoordinates.Col + displacementDownRight[1];

                bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                if (Validator.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                {
                    MoveFigure(currentCoordinates, newCoordinates);

                    BaseGame.Counter++;

                    SwitchCurrentPawnExistingMoves(currentPawn);

                    return newCoordinates;
                }
                else
                {
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            GameConstants.PawnExistingMoves[0, 1] = false;
                            break;

                        case 'B':
                            GameConstants.PawnExistingMoves[1, 1] = false;
                            break;

                        case 'C':
                            GameConstants.PawnExistingMoves[2, 1] = false;
                            break;

                        case 'D':
                            GameConstants.PawnExistingMoves[3, 1] = false;
                            break;

                        default:
                            Console.WriteLine(MessageConstants.ErrorMessage);
                            break;
                    }

                    allAreFalse = CheckingAllPawnMoves();

                    if (allAreFalse)
                    {
                        gameOver = true;
                        Console.WriteLine(MessageConstants.KingVictoryMessage, BaseGame.Counter / 2);
                        gameOver = true;
                        return null;
                    }

                    Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);
                    Thread.Sleep(400);

                    return null;
                }
            }
        }

        public static void MoveFigure(IPosition currentCoordinates, IPosition newCoordinates)
        {
            char currentPos = GetField[currentCoordinates.Row, currentCoordinates.Col];
            BaseGame.GetField[currentCoordinates.Row, currentCoordinates.Col] = ' ';
            BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] = currentPos;
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
                    if (Validator.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            GameConstants.KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(0);
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();

                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);
                        Thread.Sleep(400);
                        return null;
                    }
                }
                else
                {
                    newCoordinates.Row = currentCoordinates.Row + displacementUpRight[0];
                    newCoordinates.Col = currentCoordinates.Col + displacementUpRight[1];

                    bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Validator.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            GameConstants.KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(1);
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();

                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);
                        Thread.Sleep(400);
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
                    if (Validator.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            GameConstants.KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(2);
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();

                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);
                        Thread.Sleep(400);
                        return null;
                    }
                }
                else
                {
                    newCoordinates.Row = currentCoordinates.Row + displacementDownRight[0];
                    newCoordinates.Col = currentCoordinates.Col + displacementDownRight[1];

                    bool isEmptyCurrentCell = GetField[newCoordinates.Row, newCoordinates.Col] == ' ';
                    if (Validator.IsPositionOnTheBoard(newCoordinates) && isEmptyCurrentCell)
                    {
                        MoveFigure(currentCoordinates, newCoordinates);

                        BaseGame.Counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            GameConstants.KingExistingMoves[i] = true;
                        }

                        CheckForKingExit(newCoordinates.Row);
                        return newCoordinates;
                    }
                    else
                    {
                        bool allAreFalse = KingExistingMovesMethod(3);
                        if (allAreFalse)
                        {
                            gameOver = true;
                            CommandPrintKingLosing();

                            return null;
                        }

                        Printer.PrintMessage(ConsoleColor.DarkYellow, MessageConstants.WrongDirectionMessage);
                        Thread.Sleep(400);
                        return null;
                    }
                }
            }
        }

        public static void CommandPrintKingLosing()
        {
            Console.WriteLine(MessageConstants.KingLostMessage, BaseGame.Counter / 2);
        }

        public static void Main()
        {
            Start(BaseGame.Counter);
            Console.WriteLine(MessageConstants.GoodbyeMessage);
            Console.ReadLine();
        }

        private static bool KingExistingMovesMethod(int someMagicNumber)
        {
            GameConstants.KingExistingMoves[someMagicNumber] = false;
            bool allAreFalse = true;
            for (int i = 0; i < 4; i++)
            {
                if (GameConstants.KingExistingMoves[i])
                {
                    allAreFalse = false;
                }
            }

            return allAreFalse;
        }

        // Checks if command is KDR, KUL, etc.
        private static bool CheckIfValidKingDirection(string direction)
        {
            bool isValidDirection = false;

            foreach (var possibleDirection in GameConstants.KingPossibleDirections)
            {
                if (direction == possibleDirection)
                {
                    isValidDirection = true;
                    break;
                }
            }

            return isValidDirection;
        }

        // Checks if command is ADR, ADL, BDR, etc.
        private static bool CheckIfValidPawnDirection(string direction)
        {
            bool isValidDirection = Validator.IsValidPawnMove(direction);
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
    }
}