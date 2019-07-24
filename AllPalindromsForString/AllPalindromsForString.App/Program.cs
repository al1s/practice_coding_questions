using System;
using System.Collections.Generic;
using System.Linq;

namespace AllPalindromsForString.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }

    public List<List<string>> GetPalindromes(string str)
    {
      var allPals = new List<List<string>>();
      GetPalindromes(str.ToCharArray(), 0, allPals, 0, new List<string>());
      return allPals;
    }
    public void GetPalindromes(char[] strArr, int pivot, List<List<string>> allPals, int start, List<string> currPal)
    {
      if (pivot > strArr.Length)
      {
        if (currPal.Aggregate(0, (length, next) => length + next.Length) == strArr.Length)
        {
          allPals.Add(currPal);
        }
        return;
      }

      for (int i = pivot; i < strArr.Length; i++)
      {
        if (checkPal(strArr, start, pivot))
        {
          currPal.Add(new string(new ArraySegment(strArr, start, pivot - start)));
          GetPalindromes(strArr, pivot + 1, allPals, pivot + 1, currPal);
        }
        else
        {
          GetPalindromes(strArr, pivot + 1, allPals, start, currPal);
        }
      }
    }
  }
}
