namespace KingSurvival.ConsoleClient
{
    using System;

    public static class Printer
    {
        public static void PrintMessage(ConsoleColor color, string message)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
