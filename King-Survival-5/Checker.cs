using Commons;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KingSurvival
{
    public static class Checker
    {
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
    }
}
