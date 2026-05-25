using CtCI.Console.Menus;

namespace CtCI.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        System.Console.Title = "Cracking the Coding Interview";
        await MainMenu.ShowAsync();
    }
}
