using System;
using System.Collections.Generic;

namespace LeetCode_146_LRU.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      LRUCache cache = new LRUCache(2);
      cache.put(1, 1);
      cache.put(2, 2);
      var a = cache.get(1);       // returns 1
      System.Console.WriteLine(a);
      cache.put(3, 3);    // evicts key 2
      a = cache.get(2);       // returns -1 (not found)
      System.Console.WriteLine(a);
      cache.put(4, 4);    // evicts key 1
      a = cache.get(1);       // returns -1 (not found)
      System.Console.WriteLine(a);
      a = cache.get(3);       // returns 3
      System.Console.WriteLine(a);
      a = cache.get(4);       // returns 4
      System.Console.WriteLine(a);
    }
  }

  public class LRUCache
  {
    private int _capacity { get; }
    private int _size { get; set; } = 0;
    private LinkList _ll { get; set; } = new LinkList();
    private Node _head = new Node(0);
    private Node _tail = new Node(int.MaxValue);
    private Dictionary<int, Node> _dict { get; } = new Dictionary<int, Node>();

    public LRUCache(int capacity)
    {
      _capacity = capacity;
      _ll.Add(_head);
      _ll.Add(_tail);
    }

    public int get(int key)
    {
      Node node = null;
      if (!_dict.TryGetValue(key, out node))
      {
        return -1;
      }
      Remove(key);
      _ll.AddAfter(_head, node);
      return node.val;
    }

    public void put(int key, int n)
    {
      var node = new Node(n);

      if (_size == _capacity)
      {
        RemoveLast();
        _ll.AddAfter(_head, node);
      }

      else
      {
        _ll.AddAfter(_head, node);
        _size += 1;
      }

      _dict.Add(key, node);
    }

    private void Remove(int key)
    {
      if (_dict.TryGetValue(key, out Node node))
      {
        _dict.Remove(key);
        node.prev = node.next;
      }
    }

    private void RemoveLast()
    {
      _tail = _tail.prev;
      _tail.next = null;
    }
  }

  public class LinkList
  {
    public Node Head;
    public Node Tail;
    public LinkList()
    {
      Head = null;
      Tail = null;
    }
    public void AddAfter(Node after, Node node)
    {
      var temp = after.next;
      after.next = node;
      temp.prev = node;
      node.next = temp;
      node.prev = after;
    }

    public void Add(int val)
    {
      var node = new Node(val);
      Add(node);
    }

    public void Add(Node node)
    {
      if (Head is null)
      {
        Head = node;
        Tail = node;
      }
      else
      {
        var temp = Tail;
        Tail = node;
        temp.next = Tail;
        Tail.prev = temp;
      }
    }
  }

  public class Node
  {
    public int val;
    public Node prev;
    public Node next;
    public Node(int n)
    {
      val = n;
      prev = null;
      next = null;
    }
  }
}