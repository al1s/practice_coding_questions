using System;
using System.Collections.Generic;

namespace CombinationSum.App
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums = new int[] { 2, 3, 5 };
      var result = combinationSum(nums, 8);
      result.ForEach(elm =>
      {
        System.Console.WriteLine();
        elm.ForEach(innElm => System.Console.WriteLine($"{innElm}, "));
      });
    }
    public static List<List<int>> combinationSum(int[] nums, int target)
    {
      List<List<int>> list = new List<List<int>>();
      Array.Sort(nums);
      backtrack(list, new List<int>(), nums, target, 0);
      return list;
    }

    private static void backtrack(List<List<int>> list, List<int> tempList, int[] nums, int remain, int start)
    {
      if (remain < 0) return;
      else if (remain == 0) list.Add(new List<int>(tempList));
      else
      {
        for (int i = start; i < nums.Length; i++)
        {
          tempList.Add(nums[i]);
          backtrack(list, tempList, nums, remain - nums[i], i); // not i + 1 because we can reuse same elements
          tempList.RemoveAt(tempList.Count - 1);
        }
      }
    }
  }
}
