using CtCI.Core.Utilities;

namespace CtCI.Challenges.Easy.Arrays;

/// <summary>
/// LeetCode #26: Remove Duplicates from Sorted Array.
/// Given a sorted array, remove duplicates in-place and return the count of unique elements.
/// </summary>
public class RemoveDuplicatesFromSortedArray : IChallenge
{
    public string Name => "Remove Duplicates from Sorted Array";
    public string Description => "Given a sorted integer array, remove duplicates in-place " +
                                  "and return the number of unique elements.";
    public ChallengeDifficulty Difficulty => ChallengeDifficulty.Easy;
    public string Category => "Arrays";

    public void Run()
    {
        ConsoleHelper.WriteHeader($"Challenge: {Name}");

        var testCases = new[]
        {
            (Input: new[] { 1, 1, 2 }, Expected: 2),
            (Input: new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, Expected: 5),
        };

        foreach (var (input, expected) in testCases)
        {
            var nums = (int[])input.Clone();
            ConsoleHelper.Write($"Input:  [{string.Join(", ", input)}]  ", ConsoleColor.Gray);
            ConsoleHelper.Write($"Expected k={expected}  ", ConsoleColor.DarkGray);

            int k = RemoveDuplicates(nums);

            if (k == expected)
                ConsoleHelper.WriteSuccess($"k={k}");
            else
                ConsoleHelper.WriteError($"k={k} (expected {expected})");

            ConsoleHelper.Write($"  Result: [{string.Join(", ", nums.AsSpan(0, k).ToArray())}]",
                ConsoleColor.DarkCyan);
            ConsoleHelper.WriteLine();
        }

        ConsoleHelper.WaitForKey();
    }

    /// <summary>
    /// Two-pointer technique. O(n) time, O(1) space.
    /// </summary>
    private static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int unique = 0;
        for (int current = 1; current < nums.Length; current++)
        {
            if (nums[current] != nums[unique])
            {
                unique++;
                nums[unique] = nums[current];
            }
        }
        return unique + 1;
    }
}
