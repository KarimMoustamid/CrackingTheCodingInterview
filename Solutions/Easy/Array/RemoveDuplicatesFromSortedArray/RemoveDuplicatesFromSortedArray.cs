namespace Solutions.Easy.Array.RemoveDuplicatesFromSortedArray
{
    using Utilities;

    public static class RemoveDuplicatesFromSortedArray
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int unique = 0; // Pointer for the position of unique elements

            // Iterate through the array
            for (int current = 1; current < nums.Length; current++)
            {
                // If a new unique value is found
                if (nums[current] != nums[unique])
                {
                    unique++; // Move the unique pointer forward
                    nums[unique] = nums[current]; // Place the unique value at the new position
                }
            }

            // The number of unique elements is `unique + 1`
            return unique + 1;
        }

        public static void LogSolution(int[] nums)
        {
            ConsoleHelper.LogWithColor($"Input Array: {string.Join(',', nums)}");

            var unique = RemoveDuplicates(nums);
            ConsoleHelper.LogWithColor($"Unique Array: {string.Join(',', nums)}", ConsoleColor.Red, ConsoleColor.Black);

            ConsoleHelper.LogWithColor($"Resulting unique elements count: {unique}", ConsoleColor.DarkCyan, ConsoleColor.Black);
        }
    }
}