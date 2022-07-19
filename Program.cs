public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> compliments = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int compliment = target - nums[i];
            if (compliments.ContainsKey(compliment))
            {
                return new int[] { compliments[compliment], i };
            }
            compliments.TryAdd(nums[i], i);
        }
        return null;
    }

    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //int[] nums = new int[] { 2, 7, 11, 15 };
        //Console.WriteLine(String.Join(",", solution.TwoSum(nums, 9)));
    }
}