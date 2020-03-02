using System;
namespace Vocab3000.Utility
{
    public static class ConsoleUtility
    {
        public static void WriteForgroundColoredLine(string line, ConsoleColor color)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ForegroundColor = defaultColor;
        }

        public static void WriteForgroundColored(string line, ConsoleColor color)
        {
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(line);
            Console.ForegroundColor = defaultColor;
        }
    }
}