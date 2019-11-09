using System;
using UnionFind;

namespace UnionFind.App
{
  class Program
  {
    static void Main(string[] args)
    {
      var map = new int[3][]
      {
          new int[3] {1,1,1},
          new int[3] {1,1,0},
          new int[3] {1,0,0},
      };
      var uf = new UnionFind(map);
      var nOfI = uf.GetNumberOfIslands(map);
      Console.WriteLine($"Number of islands is {nOfI}");
    }

  }
}
