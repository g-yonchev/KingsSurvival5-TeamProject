namespace KingSurvival.ConsoleClient
{
    using System;

    public static class Printer     // <<< DELETE!!! OBSOLETE! RENDERED USES ITS METHOD
    {
        public static void PrintMessage(ConsoleColor color, string message)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}