using System;
using System.Collections.Generic;
using System.Linq;

namespace AmicableNumbers.App
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("Amicable numbers");
      var anums = AmicableNumbersLessThan(100005);
      anums.ForEach(pair => Console.WriteLine($"{pair[0]}, {pair[1]}"));
    }
    public static List<int[]> AmicableNumbersLessThan(int num)
    {
      var amicableNumbers = new List<int[]>();
      var allDivisorsSums = new int[num + 1];
      for (int i = 1; i <= num; i++)
      {
        allDivisorsSums[i] = GetSumOfDiv(i);
      }

      for (int a = 2; a <= num; a++)
      {
        var b = allDivisorsSums[a];
        if (b < num && a == allDivisorsSums[b] && a != b && a < b)
        {
          amicableNumbers.Add(new[] { a, b });
        }
      }
      return amicableNumbers;
    }

    private static int GetSumOfDiv(int i)
    {
      return GetDivisors(i).Aggregate(0, (elm, sum) => sum += elm);
    }

    private static int[] GetDivisors(int i)
    {
      var divisors = new List<int>();
      for (int j = 1; j <= Math.Sqrt(i); j++)
      {
        if (i % j == 0)
        {
          divisors.Add(j);
          if (i / j != j && i / j != i) divisors.Add(i / j);
        }
      }
      return divisors.ToArray();
    }
  }
}
