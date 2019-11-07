using System;

namespace UnionFind.App
{
  public class UnionFind
  {
    private int _count = 0;
    private int[] _parent { get; set; }
    private int[] _rank { get; set; }
    public UnionFind(int[][] map)
    {
      var rows = map.Length;
      var cols = map[0].Length;
      _parent = new int[rows * cols + cols];
      _rank = new int[rows * cols + cols];
      for (int r = 0; r < rows; r++)
      {
        for (int c = 0; c < cols; c++)
        {
          if (map[r][c] == 1)
          {
            _parent[r * cols + c] = r * cols + c;
            _count += 1;
          }
          _rank[r * cols + c] = 0;
        }
      }
    }

    public int Find(int pos)
    {
      if (_parent[pos] != pos)
      {
        _parent[pos] = Find(_parent[pos]);
      }
      return _parent[pos];
    }

    public void Union(int pos1, int pos2)
    {
      var parent1 = Find(pos1);
      var parent2 = Find(pos2);
      if (parent1 == parent2) return;
      if (_rank[parent1] < _rank[parent2]) _parent[parent1] = parent2;
      if (_rank[parent1] > _rank[parent2]) _parent[parent2] = parent1;
      if (_rank[parent1] == _rank[parent2])
      {
        _parent[parent2] = parent1;
        _rank[parent1] += 1;
      }
      _count -= 1;
    }

    public int GetCount()
    {
      return _count;
    }

    public int GetNumberOfIslands(int[][] map)
    {
      var uf = new UnionFind(map);
      var rows = map.Length;
      var cols = map[0].Length;
      for (int r = 0; r < rows; r++)
      {
        for (int c = 0; c < cols; c++)
        {
          if (map[r][c] == 1)
          {
            map[r][c] = 0;
            if (r - 1 > 0 && map[r - 1][c] == 1) uf.Union(r * cols + c, (r - 1) * rows + c); // vertical up
            if (c - 1 > 0 && map[r][c - 1] == 1) uf.Union(r * cols + c, r * rows + c - 1); // horizontal left
            if (r + 1 < rows && map[r + 1][c] == 1) uf.Union(r * cols + c, (r + 1) * rows + c); // vertical down
            if (c + 1 < cols && map[r][c + 1] == 1) uf.Union(r * cols + c, r * rows + c + 1); // horizontal right
          }
        }
      }
      return uf.GetCount();
    }
  }
}