namespace KingSurvival.ConsoleClient
{
    using System;
    using KingSurvival.GameLogic.Models;

    public static class Renderer
    {
        // Renders board and messages. Basically everything on the console
        // Coupling: BaseGame, Position;

        public static void PrintBoard(/*Board board or something*/)  // Needs some work
        {
            Console.WriteLine();
            for (int row = 0; row < BaseGame.GetField.GetLength(0); row++)
            {
                for (int col = 0; col < BaseGame.GetField.GetLength(1); col++)
                {
                    Position coordinates = new Position(row, col);
                    bool isCellIn = BaseGame.IsPositionOnTheBoard(coordinates);
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
                                Console.Write(BaseGame.GetField[row, col]);
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

        public static void PrintMessage(ConsoleColor color, string message)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        protected static void SetConsoleColor(ConsoleColor bgColor, int row, int col)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(BaseGame.GetField[row, col]);       
            Console.ResetColor();
        }

    }
}
