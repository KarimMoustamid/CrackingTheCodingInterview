# Cracking the Coding Interview — C# Study Console

A structured C# project for studying **Data Structures**, **Algorithms**, and solving **Interview Challenges** (LeetCode-style problems) through an interactive console application.

## Project Structure

```
src/
├── CtCI.Console/        Interactive menu-driven console app (entry point)
├── CtCI.Core/           Shared library: data structures, algorithms, utilities
└── CtCI.Challenges/     Interview challenges organized by difficulty & category
tests/
└── CtCI.Tests/          xUnit test project
```

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (or later)

```bash
# Verify installation
dotnet --version   # Should show 8.x.x
```

## Quick Start

```bash
# Restore dependencies and build
dotnet restore
dotnet build

# Launch the interactive console
dotnet run --project src/CtCI.Console
```

## Navigating the Console

Once running, you'll see the main menu:

```
═══════════════════════════════════════════════════
  Cracking the Coding Interview — Study Console
═══════════════════════════════════════════════════

  [1] Data Structures
  [2] Algorithms
  [3] Interview Challenges
  [0] Exit
```

- **Data Structures** — interactive demos of custom data structure implementations (Linked Lists, Stacks, Queues, Trees, Graphs, etc.)
- **Algorithms** — walkthroughs of sorting, searching, recursion, dynamic programming, and other algorithm patterns
- **Interview Challenges** — LeetCode-style problems grouped by difficulty (Easy / Medium / Hard) and category

## Adding a New Interview Challenge

1. Create a class implementing `IChallenge` in `src/CtCI.Challenges/`:

```csharp
using CtCI.Core.Utilities;

namespace CtCI.Challenges.Easy.Arrays;

public class TwoSum : IChallenge
{
    public string Name => "Two Sum";
    public string Description => "Find two numbers that add up to a target.";
    public ChallengeDifficulty Difficulty => ChallengeDifficulty.Easy;
    public string Category => "Arrays";

    public void Run()
    {
        ConsoleHelper.WriteHeader($"Challenge: {Name}");
        // Your solution + test cases here...
        ConsoleHelper.WaitForKey();
    }
}
```

2. Rebuild — the menu **auto-discovers** all `IChallenge` implementations via reflection. No manual wiring needed.

## Adding a Data Structure or Algorithm Module

1. Create a class implementing `IRunner` in `src/CtCI.Console/`:

```csharp
using CtCI.Console.Runners;
using CtCI.Core.Utilities;

namespace CtCI.Console.DataStructures;

public class LinkedListDemo : IRunner
{
    public string Name => "Singly Linked List";
    public string Description => "Implementation and common operations.";
    public void Run()
    {
        ConsoleHelper.WriteHeader(Name);
        // Demo code...
        ConsoleHelper.WaitForKey();
    }
}
```

2. Rebuild — auto-discovered and listed in the Data Structures menu.

## Running Tests

```bash
dotnet test
```

Tests live in `tests/CtCI.Tests/` and use xUnit.

## Key Interfaces

| Interface | Purpose | Location |
|---|---|---|
| `IChallenge` | Interview problems with `Run()` | `src/CtCI.Challenges/IChallenge.cs` |
| `IRunner` | Data structure & algorithm demos | `src/CtCI.Console/Runners/IRunner.cs` |

## Utilities

`CtCI.Core.Utilities.ConsoleHelper` provides helpers for colored console output:

- `WriteLine(msg, foreground, background)` — colored output
- `WriteHeader(title)` — section header with double-line border
- `WriteSuccess(msg)` / `WriteError(msg)` / `WriteWarning(msg)` — status messages
- `WaitForKey()` — pause until keypress
