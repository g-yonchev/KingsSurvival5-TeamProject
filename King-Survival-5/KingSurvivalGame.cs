namespace KingSurvival
{
    using System;
    using Models;
    using Commons;
    // -- using Contarcts;
    using Contracts;
    //using King;

    // using King.Contracts;

    public class KingSurvivalGame : BaseGame
    {
        ////private IPrinter printer;

        ////public KingSurvivalGame(IPrinter printer)
        ////{
        ////    this.printer = printer;
        ////}

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
                    bool isCellIn = Checker.IsPositionOnTheBoard(coordinates);
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
                return;
            }
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
                    continue;
                }

                bool isValidDirection = Checker.CheckIfValidKingDirection(input);
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

        public static void ProcessPawnTurn()
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
                    isExecuted = Checker.CommandCheck(input);
                }
                else
                {
                    isExecuted = false;

                    Printer.PrintMessage(ConsoleColor.DarkRed, MessageConstants.EmptyStringMessage);
                }
            }

            Start(Counter);
        }

        ////static void CommandPrintWrongDirection()
        ////{
        ////    Console.BackgroundColor = ConsoleColor.DarkYellow;
        ////    Console.WriteLine(Constants.WRONG_DIRECTION_MESSAGE);
        ////    Console.ResetColor();
        ////}

        public static void Main()
        {
            //IPrinter printer = new Printer();
            Start(Counter);
            Console.WriteLine(MessageConstants.GoodbyeMessage);
            Console.ReadLine();
        }
    }
}