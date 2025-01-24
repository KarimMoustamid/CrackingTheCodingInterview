namespace Solutions.Utilities
{
    public static class ConsoleHelper
    {
        public static void LogWithColor(string message,
            ConsoleColor? backgroundColor = ConsoleColor.Black, ConsoleColor? foregroundColor = ConsoleColor.Green)
        {
            var originalForegroundColor = Console.ForegroundColor;
            var originalBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor ?? originalForegroundColor;
            Console.BackgroundColor = backgroundColor ?? originalBackgroundColor;

            Console.WriteLine($"{message}");

            Console.ForegroundColor = originalForegroundColor;
            Console.BackgroundColor = originalBackgroundColor;
        }
    }
}