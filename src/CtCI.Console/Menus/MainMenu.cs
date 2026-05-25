using CtCI.Console.Runners;
using CtCI.Challenges; // Force assembly load for reflection discovery
using CtCI.Core.Utilities;

namespace CtCI.Console.Menus;

/// <summary>
/// Discovers all IRunner implementations (Data Structures, Algorithms) and IChallenge
/// implementations (Interview Challenges) via reflection, then presents an interactive menu.
/// </summary>
public static class MainMenu
{
    public static async Task ShowAsync()
    {
        var runners = DiscoverRunners();
        var challenges = DiscoverChallenges();

        while (true)
        {
            System.Console.Clear();
            ConsoleHelper.WriteHeader("Cracking the Coding Interview — Study Console");

            ConsoleHelper.WriteLine("  [1] Data Structures", ConsoleColor.White);
            ConsoleHelper.WriteLine("  [2] Algorithms", ConsoleColor.White);
            ConsoleHelper.WriteLine("  [3] Interview Challenges", ConsoleColor.White);
            ConsoleHelper.WriteLine("  [0] Exit", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine();

            var key = ReadChoice(0, 3);

            switch (key)
            {
                case 1:
                    ShowModuleMenu("Data Structures", runners
                        .Where(r => r.GetType().Namespace?.Contains("DataStructures") == true)
                        .ToList());
                    break;
                case 2:
                    ShowModuleMenu("Algorithms", runners
                        .Where(r => r.GetType().Namespace?.Contains("Algorithms") == true)
                        .ToList());
                    break;
                case 3:
                    ShowChallengeMenu(challenges);
                    break;
                case 0:
                    ConsoleHelper.WriteLine("Goodbye!", ConsoleColor.Cyan);
                    return;
            }
        }
    }

    private static void ShowModuleMenu(string title, List<IRunner> modules)
    {
        if (modules.Count == 0)
        {
            ConsoleHelper.WriteWarning($"No {title.ToLower()} modules found yet. " +
                                        "Implement IRunner to add them.");
            ConsoleHelper.WaitForKey();
            return;
        }

        while (true)
        {
            System.Console.Clear();
            ConsoleHelper.WriteHeader(title);

            for (int i = 0; i < modules.Count; i++)
                ConsoleHelper.WriteLine($"  [{i + 1}] {modules[i].Name} — {modules[i].Description}",
                    ConsoleColor.White);

            ConsoleHelper.WriteLine($"  [0] Back", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine();

            int choice = ReadChoice(0, modules.Count);
            if (choice == 0) return;

            System.Console.Clear();
            modules[choice - 1].Run();
            ConsoleHelper.WaitForKey();
        }
    }

    private static void ShowChallengeMenu(List<Challenges.IChallenge> challenges)
    {
        if (challenges.Count == 0)
        {
            ConsoleHelper.WriteWarning("No challenges found. Implement IChallenge to add them.");
            ConsoleHelper.WaitForKey();
            return;
        }

        while (true)
        {
            System.Console.Clear();
            ConsoleHelper.WriteHeader("Interview Challenges");

            var grouped = challenges
                .GroupBy(c => c.Difficulty)
                .OrderBy(g => g.Key);

            int index = 1;
            var indexed = new Dictionary<int, Challenges.IChallenge>();

            foreach (var group in grouped)
            {
                var color = group.Key switch
                {
                    Challenges.ChallengeDifficulty.Easy => ConsoleColor.Green,
                    Challenges.ChallengeDifficulty.Medium => ConsoleColor.Yellow,
                    Challenges.ChallengeDifficulty.Hard => ConsoleColor.Red,
                    _ => ConsoleColor.Gray
                };
                ConsoleHelper.WriteLine($"  --- {group.Key} ---", color);

                foreach (var challenge in group.OrderBy(c => c.Category).ThenBy(c => c.Name))
                {
                    ConsoleHelper.Write($"  [{index,2}] ", ConsoleColor.DarkGray);
                    ConsoleHelper.Write($"[{challenge.Category}] ", ConsoleColor.DarkCyan);
                    ConsoleHelper.WriteLine($"{challenge.Name}", ConsoleColor.White);
                    indexed[index] = challenge;
                    index++;
                }
                ConsoleHelper.WriteLine();
            }

            ConsoleHelper.WriteLine($"  [0] Back", ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine();

            int choice = ReadChoice(0, indexed.Count);
            if (choice == 0) return;

            System.Console.Clear();
            indexed[choice].Run();
        }
    }

    private static int ReadChoice(int min, int max)
    {
        while (true)
        {
            ConsoleHelper.Write("  Choose > ", ConsoleColor.Yellow);
            var input = System.Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= min && choice <= max)
                return choice;

            ConsoleHelper.WriteWarning($"Please enter {min}-{max}.");
        }
    }

    private static List<IRunner> DiscoverRunners()
    {
        return typeof(MainMenu).Assembly
            .GetTypes()
            .Where(t => typeof(IRunner).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IRunner>()
            .ToList();
    }

    private static List<Challenges.IChallenge> DiscoverChallenges()
    {
        // IChallenge lives in CtCI.Challenges, which is referenced by this project.
        // We scan all loaded assemblies for implementations.
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a =>
            {
                try { return a.GetTypes(); }
                catch { return Type.EmptyTypes; }
            })
            .Where(t => typeof(Challenges.IChallenge).IsAssignableFrom(t)
                        && !t.IsInterface && !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<Challenges.IChallenge>()
            .ToList();
    }
}
