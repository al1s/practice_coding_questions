using System;
using System.Collections.Generic;

namespace _5._2_ConvertToBinary.App
{
  class Program
  {
    static void Main(string[] args)
    {
      int num = 42;
      System.Console.WriteLine($"{num} = {ConvertToBinary(num)}");
      num = 1775;
      System.Console.WriteLine($"Winning combination for {num} is {WinByFlip(num)} long");
    }

    public static string ConvertToBinary(int num)
    {
      List<int> result = new List<int>();
      int innerResult = num;
      while (innerResult > 0)
      {
        result.Add(innerResult % 2);
        innerResult /= 2;
      }

      result.Reverse();
      return string.Join(String.Empty, result);
    }

    public static int WinByFlip(int num)
    {
      string binaryRep = ConvertToBinary(num);
      string[] arr = binaryRep.Split('0');
      int max = 0;
      for (int i = 0; i < arr.Length - 1; i++)
      {
        int currValue = arr[i].Length + arr[i + 1].Length;
        max = max < currValue ? currValue : max;
      }
      return max + 1; // 1 is for 0 that was splitted out
    }
  }
}
