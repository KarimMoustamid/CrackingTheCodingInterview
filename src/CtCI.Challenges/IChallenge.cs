using CtCI.Core.Utilities;

namespace CtCI.Challenges;

/// <summary>
/// Every interview challenge implements this interface so the console
/// runner can discover and execute them via reflection.
/// </summary>
public interface IChallenge
{
    /// <summary>Human-readable name displayed in menus.</summary>
    string Name { get; }

    /// <summary>Short description of the problem.</summary>
    string Description { get; }

    /// <summary>Difficulty level.</summary>
    ChallengeDifficulty Difficulty { get; }

    /// <summary>Category (e.g. "Arrays", "Linked Lists", "Dynamic Programming").</summary>
    string Category { get; }

    /// <summary>Execute the challenge solution and print results to console.</summary>
    void Run();
}

public enum ChallengeDifficulty
{
    Easy,
    Medium,
    Hard
}
