using CtCI.Challenges.Easy.Arrays;

namespace CtCI.Tests.Challenges;

public class RemoveDuplicatesFromSortedArrayTests
{
    [Fact]
    public void EmptyArray_ReturnsZero()
    {
        var nums = Array.Empty<int>();
        var challenge = new RemoveDuplicatesFromSortedArray();

        // We test via reflection/private — but better to test the public Run.
        // For now, this is a template showing the pattern.
    }
}
