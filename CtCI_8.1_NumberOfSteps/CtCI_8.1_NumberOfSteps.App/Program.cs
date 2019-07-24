using System;

namespace CtCI_8._1_NumberOfSteps.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var n = 4;
      Console.WriteLine($"Can run up {n} steps in {GetNumberOfWays(n).ToString()} ways");
    }

    public static int GetNumberOfWays(int n)
    {
      var numberOfWays = 0;
      if (n <= 0) return 0;
      var jumpInSteps = new[] { 1, 2, 3 };
      foreach (var jump in jumpInSteps)
      {
        numberOfWays += 1 + GetNumberOfWays(n - jump);
      }
      return numberOfWays;
    }
  }
}
