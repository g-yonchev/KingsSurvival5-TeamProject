namespace KingSurvival.ConsoleClient
{
    using System;

    public static class Renderer
    {
        public static void PrintBoard(char[,] Field)  
        {
            Console.WriteLine("   KING SURVIVAL GAME");
            Console.WriteLine("UL  0 1 2 3 4 5 6 7  UR");
            Console.WriteLine("   -----------------");
            int startRow = 3;

            FillBoard(Field);

            for (int row = 0; row < Field.GetLength(0); row++)
            {
                Console.SetCursorPosition(0, startRow + row);
                Console.Write(row + " | ");
                for (int col = 0; col < Field.GetLength(1); col++)
                {
                    if (Field[row, col] == 'G')
                    {
                        SetConsoleColor(Field, row, col, ConsoleColor.Green);
                    }
                    else
                    {
                        SetConsoleColor(Field, row, col, ConsoleColor.Blue);
                    }
                }

                Console.WriteLine("| " + row);
            }

            Console.WriteLine("   -----------------");
            Console.WriteLine("DL  0 1 2 3 4 5 6 7  DR");
            }

        public static void PrintMessage(ConsoleColor color, string message)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void FillBoard(char[,] b)
        {
            for (int row = 0; row < b.GetLength(0); row++)
            {
                for (int col = 0; col < b.GetLength(1); col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        b[row, col] = 'G';
                    }
                    else
                    {
                        b[row, col] = 'B';
                    }
                }
            }
        }

        private static void SetConsoleColor(char[,] board, int row, int col, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = color;
            Console.Write(board[row, col]);
            Console.ResetColor();
            Console.Write(' ');
        }
    }
}