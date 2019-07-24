using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_264_Ugly_Nums_II.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      int num = 7;
      //   System.Console.WriteLine(GetNthNum(num));
      num = 10;
      //   System.Console.WriteLine(GetNthNum(num));
      num = 15;
      System.Console.WriteLine(GetNthNum(num));
      num = 150;
      //   System.Console.WriteLine(GetNthNum(num));
    }

    public static int GetNthNum(int num)
    {
      int p2 = 1;
      int p3 = 1;
      int p5 = 1;
      int n = 1;
      var nums = new int[num];
      nums[0] = 1;
      var nums2 = 2;
      var nums3 = 3;
      var nums5 = 5;
      while (n < num)
      {
        var currNum = Math.Min(Math.Min(nums2, nums3), nums5);
        nums[n++] = currNum;
        if (currNum == nums2) { nums2 = nums[p2] * 2; p2 += 1; }
        if (currNum == nums3) { nums3 = nums[p3] * 3; p3 += 1; }
        if (currNum == nums5) { nums5 = nums[p5] * 5; p5 += 1; }
      }
      return nums[num - 1];
    }

    public static int GetNthNumBroken(int num)
    {
      var cache = new SortedDictionary<int, bool>();
      cache.Add(1, true);
      PopulateCache(cache, new[] { 2, 3, 5 }, num);
      return cache.Keys.ToArray()[num - 1];
    }

    private static void PopulateCache(SortedDictionary<int, bool> cache, int[] factors, int num)
    {
      var n = 0;
      while (cache.Count < num * 3)
      {
        var curr = cache.Keys.ToArray()[n++];
        foreach (var factor in factors)
        {
          for (int i = cache.Count - 1; i >= 0; i--)
          {
            var calcV = cache.Keys.ToArray()[i] * factor;
            if (calcV <= curr)
            {
              break;
            }
            if (!cache.TryGetValue(calcV, out _))
            {
              cache.Add(calcV, true);
            }
          }
        }
      }
    }
  }
}
