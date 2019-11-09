using System;

namespace MergeKLinkedLists.App
{
  public class LinkedList
  {
    public ListNode Head { get; set; }
    public ListNode Current { get; set; }
    public LinkedList(ListNode node)
    {
      Head = node;
      Current = node;
    }
    public void Add(ListNode node)
    {
      Current.next = node;
      Current = node;
    }
  }
}