using System;
using System.Collections.Generic;

namespace _4._9_RecoverArraysCanBuildBST.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Tree bst = new Tree();
      bst.Root = new Node(4);
      bst.Root.LC = new Node(2);
      bst.Root.RC = new Node(6);
      bst.Root.LC.LC = new Node(1);
      bst.Root.LC.RC = new Node(3);
      /*
      bst.Root.RC.LC = new Node(5);
      bst.Root.RC.RC = new Node(7);
 */
      var a = RestoreArrsFrom(bst, 5);
      Console.ReadLine();

    }

    /// <summary>
    /// Restore all arrays which could form a given binary search tree.
    /// </summary>
    /// <param name="bst">A binary search tree</param>
    /// <param name="treeCount">Number of all nodes in a given tree</param>
    /// <returns>List of all lists</returns>
    public static List<List<int>> RestoreArrsFrom(Tree bst, int treeCount)
    {
      var result = new List<List<int>>();
      var stable = new List<Node>(new Node[] { bst.Root });
      var mutating = new LinkedList<Node>(new Node[] { bst.Root.LC, bst.Root.RC });
      FindArr(stable, mutating, result, treeCount);
      return result;
    }

    /// <summary>
    /// Collect all arrays into a result list for a given initial set
    /// </summary>
    /// <param name="stable">Stable part of a resulting array (list)</param>
    /// <param name="mutating">Changing part of a resulting array (list) - all elements for which an order doesn't matter</param>
    /// <param name="result">Resulting list of arrays (lists)</param>
    /// <param name="expectedLength">Expected length of the final array (list) which is a number of all nodes in a tree</param>
    public static void FindArr(List<Node> stable, LinkedList<Node> mutating, List<List<int>> result, int expectedLength)
    {
      foreach (var elm in mutating)
      {
        var newStable = new List<Node>(stable);
        var newMutating = new LinkedList<Node>(mutating);
        newMutating.Remove(elm);
        newStable.Add(elm);
        if (elm.LC != null) newMutating.AddLast(elm.LC);
        if (elm.RC != null) newMutating.AddLast(elm.RC);
        FindArr(newStable, newMutating, result, expectedLength);
      }
      if (stable.Count == expectedLength)
      {
        result.Add(ExtractValues(stable));
      }
    }


    /// <summary>
    /// Convert list of nodes into list of integers
    /// </summary>
    /// <param name="list">List of nodes</param>
    /// <return>List of integers</param>
    public static List<int> ExtractValues(List<Node> list)
    {
      var result = new List<int>();
      foreach (var elm in list)
      {
        result.Add(elm.Value);
      }
      return result;
    }
  }



  /// <summary>
  /// Basic Tree structure
  /// </summary>
  public class Tree
  {
    public Node Root { get; set; }
  }

  /// <summary>
  /// Basic Node structure
  /// </summary>
  public class Node
  {
    public int Value { get; set; }
    public Node LC { get; set; }
    public Node RC { get; set; }
    public Node(int value)
    {
      Value = value;
    }
  }
}
