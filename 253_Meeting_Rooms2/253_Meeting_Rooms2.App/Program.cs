using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _253_Meeting_Rooms2.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
    }

    public static int GetRooms(int[][] meetings)
    {
      if (meetings.Length == 0 || meetings[0].Length == 0) return 0;
      var rooms = 0;
      var startTime = meetings.Select(x => x[0]).ToArray();
      var endTime = meetings.Select(x => x[1]).ToArray();
      Array.Sort(startTime);
      Array.Sort(endTime);
      var end = 0;

      foreach (var start in startTime)
      {
        if (start >= endTime[end])
        {
          end += 1;
        }
        else
        {
          rooms += 1;
        }
      }

      return rooms;
    }

    public static string ListOfArrs2String(int[][] arrs)
    {
      var str = new StringBuilder();
      foreach (var item in arrs)
      {
        str.Append($"[{item[0]},{item[1]}],");
      }
      return str.ToString();
    }
  }
}
