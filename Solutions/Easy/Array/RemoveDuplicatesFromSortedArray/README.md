## Remove Duplicates from Sorted Array

### Solution
> **Given:** An integer array `nums` sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in `nums`.

#### Steps to Follow:
- Modify the array `nums` such that the first `k` elements of `nums` contain the unique elements in the order they were present in `nums` initially.
- The remaining elements of `nums` are irrelevant and do not affect the solution.
- Return `k`.

> **Note: Custom Judge**

The judge will test your solution with the following C# code:

```csharp
int[] nums = { ... }; // Input array
int[] expectedNums = { ... }; // The expected answer with correct length

int k = RemoveDuplicates(nums); // Calls your implementation

Debug.Assert(k == expectedNums.Length);
for (int i = 0; i < k; i++)
{
    Debug.Assert(nums[i] == expectedNums[i]);
}
```
If all assertions pass, then your solution will be accepted.

---

### Examples

#### Example 1:

```plaintext
Input: nums = [1,1,2]
Output: 2, nums = [1,2,_]
Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2.
It does not matter what you leave beyond the returned k (indicated as `_`).
```

#### Example 2:

```plaintext
Input: nums = [0,0,1,1,1,2,2,3,3,4]
Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4.
It does not matter what you leave beyond the returned k.
```

---

### Constraints
- `1 <= nums.Length <= 3 * 10^4`
- `-100 <= nums[i] <= 100`
- `nums` is sorted in non-decreasing order.

---

### C# Solution

Here's a functional C# implementation of the solution:

```csharp
public int RemoveDuplicates(int[] nums)
{
    if (nums.Length == 0) return 0;

    int slow = 0;

    for (int fast = 1; fast < nums.Length; fast++)
    {
        if (nums[fast] != nums[slow])
        {
            slow++;
            nums[slow] = nums[fast];
        }
    }

    return slow + 1;
}
```

---

### Explanation of the Code:

1. **Initialize Pointers**:
    - `slow` pointer represents the position of the last unique element in the modified array.
    - `fast` pointer scans the array to find unique elements.

2. **Iterate Through Array**:
    - Compare `nums[fast]` with `nums[slow]`.
    - If they are different, move the `slow` pointer forward and overwrite with the new unique element found by the `fast` pointer.

3. **Return the Count of Unique Elements**:
    - Since `slow` is 0-based, the final count is `slow + 1`.

---

### Complexity Analysis:

- **Time Complexity**: `O(n)`
    - The array is traversed only once using the `fast` pointer.
- **Space Complexity**: `O(1)`
    - In-place modification ensures no extra space is used.