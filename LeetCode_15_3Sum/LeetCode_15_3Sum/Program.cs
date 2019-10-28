using System;
using System.Collections.Generic;

namespace LeetCode_15_3Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var nums = new[] { 3, -1, 0, 1, 2, -1, -4 };
            //var res = GetThreeSum(nums);

            var nums = new[] { -2, 0, 0, 2, 2 };
            var res = GetThreeSum(nums);
        }

        private static IList<IList<int>> GetThreeSum(int[] nums)
        {
            var satisfyingNums = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length / 2; i++) // go to the center of array, everything above will not satisfy
            {
                if (nums[i] > 0)
                {
                    break;
                }

                if (i == 0 || nums[i] != nums[i - 1]) // skip same numbers for i position
                {
                    var lo = i + 1;
                    var hi = nums.Length - 1;

                    while (lo < hi)
                    {
                        if (nums[i] + nums[lo] + nums[hi] == 0)
                        {
                            satisfyingNums.Add(new List<int>() { nums[i], nums[lo], nums[hi] });
                            while (lo < hi && nums[lo] == nums[lo - 1]) lo += 1; // skip same numbers for lo position
                            while (lo < hi && nums[hi] == nums[hi = 1]) hi -= 1; // skip same numbers for hi position
                            lo += 1;
                            hi -= 1;
                        }
                        else if (nums[lo] + nums[hi] < 0 - nums[i]) // raise lower bound to satisfy equality
                        {
                            lo += 1;
                        }
                        else // decline upper bound
                        {
                            hi -= 1;
                        }
                    }
                }
            }
            return (IList<IList<int>>)satisfyingNums;
        }
    }
}