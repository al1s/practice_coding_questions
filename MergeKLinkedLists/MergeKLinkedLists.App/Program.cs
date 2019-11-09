using System;

namespace MergeKLinkedLists.App
{
  class Program
  {
    static void Main(string[] args)
    {
      var ll1 = new LinkedList(new ListNode(1));
      ll1.Add(new ListNode(4));
      ll1.Add(new ListNode(5));
      var ll2 = new LinkedList(new ListNode(1));
      ll2.Add(new ListNode(3));
      ll2.Add(new ListNode(4));
      var ll3 = new LinkedList(new ListNode(2));
      ll3.Add(new ListNode(6));
      MergeKLists(new ListNode[] { ll1.Head, ll2.Head, ll3.Head });
    }
    public static ListNode MergeKLists(ListNode[] lists)
    {
      var start = new ListNode(-1);
      var prev = start;
      var next = FindNext(lists);
      while (next != null)
      {
        prev.next = next;
        next = next.next;
        prev = next;
        next = FindNext(lists);
      }
      return start.next;
    }

    private static ListNode FindNext(ListNode[] lists)
    {
      var minElm = lists[0];
      foreach (var item in lists)
      {
        if (item is null)
        {
          continue;
        }

        if (minElm.val > item.val)
        {
          minElm = item;
        }
      }
      return minElm;
    }
  }
}
