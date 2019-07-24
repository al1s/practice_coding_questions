using System;

namespace LeetCode_120_Triangle.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var nums = new int[][]
      {
            new[] {2},
            new[] {3,4},
            new[] {3,5,1},
            new[] {4,1,8,3},
      };

      var sum = GetTriangleMinSum(nums);
      Console.WriteLine(sum);

      nums = new int[][]
      {
            new[] {2},
            new[] {3,4},
            new[] {6,5,1},
            new[] {4,1,8,3},
      };
      sum = GetTriangleMinSum(nums);
      Console.WriteLine(sum);

      nums = new int[][]
      {
            new[] {2},
            new[] {3,4},
            new[] {6,5,7},
            new[] {4,1,8,3},
      };
      sum = GetTriangleMinSum(nums);
      Console.WriteLine(sum);
    }

    public static int GetTriangleMinSum(int[][] nums)
    {
      return nums[0][0] + Math.Min(GetTriangleMinSum(nums, 1, 0), GetTriangleMinSum(nums, 1, 1));
    }

    private static int GetTriangleMinSum(int[][] nums, int row, int col)
    {
      if (row == nums.Length || col == nums[row].Length) return 0;
      return nums[row][col] + Math.Min(GetTriangleMinSum(nums, row + 1, col), GetTriangleMinSum(nums, row + 1, col + 1));
    }
  }
}
