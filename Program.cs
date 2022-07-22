﻿
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
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> list = new List<IList<int>>();
        list.Add(new List<int>());
        list.ElementAt(0).Add(1);

        for(int rowNum = 1; rowNum < numRows; rowNum++)
        {
            List<int> row = new List<int>();
            List<int> prevRow = (List<int>)list.ElementAt(rowNum - 1);
            row.Add(1);

            for (int j = 0; j < rowNum; j++)
            {
                row.Add(prevRow.ElementAt(j - 1) + prevRow.ElementAt(j));
            }
            row.Add(1);
            list.Add(row);
        }
        return list;
    }
    Dictionary<string, int> messages = new Dictionary<string, int>();
    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (!messages.ContainsKey(message))
        {
            messages.Add(message, timestamp);
            return true;
        }
        int oldStamp = messages[message];
        if(timestamp - oldStamp >= 10)
        {
            messages.Add(message, timestamp);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = 0; i < nums2.Length; i++)
        {
            nums1[m + i] = nums2[i];
        }
        Array.Sort(nums1);
    }
    public void MergeSrt(int[] nums1, int m, int[] nums2, int n)
    {
        int r1 = m - 1;
        int r2 = n - 1;
        for (int w = m + n - 1; w >= 0; w--)
        {
            if (r1 >= 0 && r2 >= 0)
            {
                nums1[w] = nums1[r1] > nums2[r2] ? nums1[r1--] : nums2[r2--];
            }else if(r1 >= 0)
            {
                nums1[w] = nums1[r1--];
            }
            else
            {
                nums1[w] = nums2[r2--];
            }
        }
        return;
    }
    public int MajorityElement(int[] nums)
    {
        int n = nums.Length - 1;
        int majority = n / 2;
        Dictionary<int, int> m = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (m.ContainsKey(num))
            {
                m[num]++;
            }
            else
            {
                m.Add(num, 1);
            }
        }
        foreach (var a in m)
        {
            if (a.Value > majority)
            {
                return a.Key;
            }
        }
        return -1;
    }
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //int[] nums = new int[] { 2, 7, 11, 15 };
        //Console.WriteLine(String.Join(",", solution.TwoSum(nums, 9)));
        //Console.WriteLine(solution.ShouldPrintMessage(1, "foo"));
        //Console.WriteLine(solution.ShouldPrintMessage(2, "foo"));
        //int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
        //int[] nums2 = new int[] { 2, 5, 6 };
        //solution.MergeSrt(nums1, 3, nums2, 3);
        int[] nums = new int[] { 6, 5, 5 };
        Console.WriteLine(solution.MajorityElement(nums));
    }
}