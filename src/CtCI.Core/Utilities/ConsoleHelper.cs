namespace CtCI.Core.Utilities;

/// <summary>
/// Helper for colored console output used across all study modules.
/// </summary>
public static class ConsoleHelper
{
    public static void Write(string message,
        ConsoleColor? foreground = null,
        ConsoleColor? background = null)
    {
        var prevFg = Console.ForegroundColor;
        var prevBg = Console.BackgroundColor;

        if (foreground.HasValue) Console.ForegroundColor = foreground.Value;
        if (background.HasValue) Console.BackgroundColor = background.Value;

        Console.Write(message);

        Console.ForegroundColor = prevFg;
        Console.BackgroundColor = prevBg;
    }

    public static void WriteLine(string message,
        ConsoleColor? foreground = null,
        ConsoleColor? background = null)
    {
        Write(message + Environment.NewLine, foreground, background);
    }

    public static void WriteHeader(string title)
    {
        WriteLine(new string('═', 60), ConsoleColor.DarkCyan);
        WriteLine($"  {title}", ConsoleColor.Cyan);
        WriteLine(new string('═', 60), ConsoleColor.DarkCyan);
        WriteLine();
    }

    public static void WriteSuccess(string message)
        => WriteLine($"✓ {message}", ConsoleColor.Green);

    public static void WriteError(string message)
        => WriteLine($"✗ {message}", ConsoleColor.Red);

    public static void WriteWarning(string message)
        => WriteLine($"⚠ {message}", ConsoleColor.Yellow);

    public static void WaitForKey(string prompt = "Press any key to continue...")
    {
        WriteLine();
        Write(prompt, ConsoleColor.DarkGray);
        Console.ReadKey(intercept: true);
        WriteLine();
    }
}
