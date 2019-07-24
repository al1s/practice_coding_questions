using System;
using System.Collections.Generic;

namespace CtCI_8._5_Recursive_Multiply.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var powers = GetPowersOfTwo(5);
      powers.ForEach(elm => Console.Write($"{elm}, "));

      int a = 3;
      int b = 5;
      System.Console.WriteLine($"{a} * {b} = {minProduct(a, b)}");
    }

    public static int minProduct(int a, int b)
    {
      int bigger = a < b ? b : a;
      int smaller = a < b ? a : b;
      return minProductHelper(smaller, bigger);
    }

    public static int minProductHelper(int smaller, int bigger)
    {
      if (smaller == 0) return 0;
      if (smaller == 1) return bigger;

      int s = smaller >> 1;
      int side1 = minProduct(s, bigger);
      int side2 = side1;
      if (smaller % 2 == 1)
      {
        side2 = minProductHelper(smaller - s, bigger);
      }

      return side1 + side2;
    }

    public static List<int> GetPowersOfTwo(int n)
    {
      List<int> vector = new List<int>();
      List<int> powers = new List<int>();

      while (n > 0)
      {
        vector.Add(n % 2);
        n /= 2;
      }

      for (int i = 0; i < vector.Count; i++)
      {
        if (vector[i] == 1)
        {
          powers.Add(i);
        }
      }

      return powers;
    }
  }
}
