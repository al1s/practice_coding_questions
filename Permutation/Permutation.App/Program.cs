using System;
using System.Collections.Generic;

namespace Permutation.App
{
  public class Program
  {
    static void Main(string[] args)
    {
      int[] nums = new int[] { 1, 2, 3, 4 };
      var result = GetPermutations(nums);
      result.ForEach(elm =>
      {
        System.Console.WriteLine();
        elm.ForEach(innElm => System.Console.Write($"{innElm}, "));
      });

    }

    public static List<List<int>> GetPermutations(int[] nums)
    {
      var permutations = new List<List<int>>();
      GetPermutations(new List<int>(), new List<int>(nums), permutations);
      return permutations;
    }

    private static void GetPermutations(List<int> stable, List<int> mutating, List<List<int>> permutations)
    {
      if (mutating.Count == 0)
      {
        permutations.Add(new List<int>(stable));
        return;
      }

      for (int i = 0; i < mutating.Count; i++)
      {
        stable.Add(mutating[i]);
        var currMutating = new List<int>(mutating);
        currMutating.RemoveAt(i);
        GetPermutations(stable, currMutating, permutations);
        stable.RemoveAt(stable.Count - 1);
      }

    }
  }
}
