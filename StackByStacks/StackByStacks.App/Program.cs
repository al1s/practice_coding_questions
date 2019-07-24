using System;
using System.Collections.Generic;

namespace StackByStacks.App
{
  public static class Program
  {
    public static void Main()
    {
      var s = new StackByStacks<int>();
      s.Push(1);
      s.Push(2);
      s.Push(3);
      s.Push(4);
      s.Push(5);
      s.Push(6);
      Console.WriteLine(s.Pop());
      Console.WriteLine(s.Pop());
      Console.WriteLine(s.Pop());
      Console.WriteLine(s.Pop());
      Console.WriteLine(s.Pop());
      Console.WriteLine(s.Pop());
      Console.WriteLine(s.Pop());
    }
  }

  public class StackByStacks<T>
  {
    private Stack<T>[] stacks = new Stack<T>[10];
    private int[] stackLengths = new int[10];
    private int threshold = 4;
    private int current = 0;

    public void Push(T value)
    {
      if (stackLengths[current] == threshold) current += 1;
      if (current > 10) throw new Exception("Stack overflow");
      if (stacks[current] == null) stacks[current] = new Stack<T>();
      stackLengths[current] += 1;
      stacks[current].Push(value);
      Console.WriteLine(current);
      Console.WriteLine(stacks[current].Peek());
    }

    public bool IsEmpty()
    {
      return (current == 0 && stacks[current].Count == 0) || current < 0;
    }

    public T Pop()
    {
      if (IsEmpty()) throw new Exception("Stack is empty");
      if (stacks[current].Count == 0)
      {
        current -= 1;
        return Pop();
      }
      stackLengths[current] -= 1;
      return stacks[current].Pop();
    }
  }
}