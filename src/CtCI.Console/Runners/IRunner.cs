namespace CtCI.Console.Runners;

/// <summary>
/// Represents a runnable study module (a data structure demo or algorithm walkthrough).
/// </summary>
public interface IRunner
{
    string Name { get; }
    string Description { get; }
    void Run();
}
