using System;

namespace LeetCode_622_Design_Circular_Queue
{
  public class CircularQueue
  {
    /*
    Requirements:
      MyCircularQueue(k): Constructor, set the size of the queue to be k.
      Front: Get the front item from the queue. If the queue is empty, return -1.
      Rear: Get the last item from the queue. If the queue is empty, return -1.
      enQueue(value): Insert an element into the circular queue. Return true if the operation is successful.
      deQueue(): Delete an element from the circular queue. Return true if the operation is successful.
      isEmpty(): Checks whether the circular queue is empty or not.
      isFull(): Checks whether the circular queue is full or not.
    */
    private Node _front { get; set; }
    private Node _rear { get; set; }
    private int _capacity { get; set; }
    private int _size { get; set; } = 0;

    public CircularQueue(int k)
    {
      if (k < 1)
      {
        throw new ArgumentException("Size should be greater than 0");
      }

      _capacity = k;
    }

    public int Front()
    {
      return _front is null ? -1 : _front.Val;
    }

    public int Rear()
    {
      return _rear is null ? -1 : _rear.Val;
    }

    public bool isEmpty()
    {
      return _size == 0;
    }

    public bool isFull()
    {
      return _size == _capacity;
    }

    public bool enQueue(int value)
    {
      if (_size == _capacity)
      {
        return false;
      }

      var node = new Node(value);
      if (_front is null)
      {
        _front = node;
        _rear = node;
      }
      else
      {
        var temp = _rear;
        temp.Next = node;
        node.Prev = temp;
        _rear = node;
      }
      _size += 1;
      return true;
    }

    public bool deQueue()
    {
      if (_size == 0)
      {
        return false;
      }
      else
      {
        var temp = _front;
        _front = temp.Next;
        _size -= 1;
        return true;
      }
    }
  }

  public class Node
  {
    public int Val { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }
    public Node(int val)
    {
      Val = val;
      Next = null;
      Prev = null;
    }
  }
}