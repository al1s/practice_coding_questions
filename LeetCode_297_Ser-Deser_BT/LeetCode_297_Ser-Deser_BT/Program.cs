using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_297_Ser_Deser_BT
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            // 1,2,3,null,null,4,5
            var head = new Node(1);
            head.left = new Node(2);
            head.right = new Node(3);
            head.right.left = new Node(4);
            head.right.right = new Node(5);
            var str = SerializeBT(head);
            System.Console.WriteLine(str);
            var tree = DeserializeBT(str);

            // [5,2,3,null,null,2,4,3,1]
            head = new Node(5);
            head.left = new Node(2);
            head.right = new Node(3);
            head.right.left = new Node(2);
            head.right.right = new Node(4);
            head.right.left.left = new Node(3);
            head.right.left.right = new Node(1);
            str = SerializeBT(head);
            System.Console.WriteLine(str);
            tree = DeserializeBT(str);

            head = new Node(1);
            head.left = new Node(2);
            str = SerializeBT(head);
            System.Console.WriteLine(str);
            tree = DeserializeBT(str);
        }

        public static string SerializeBT(Node head)
        {
            var separator = ",";
            var nullValue = "null";
            var queue = new Queue<Node>();
            var serializedTree = new StringBuilder();
            queue.Enqueue(head);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (curr is null)
                {
                    serializedTree.Append(nullValue).Append(separator);
                    continue;
                }
                serializedTree.Append(curr.val).Append(separator);
                queue.Enqueue(curr.left);
                queue.Enqueue(curr.right);
            }
            return RemoveTrailingNulls(serializedTree.ToString());
        }

        public static Node DeserializeBT(string str)
        {
            var strArr = str.Split(',');
            var nodes = new Queue<Node>();
            if (strArr[0].Equals("null")) return null;
            nodes.Enqueue(new Node(Int32.Parse(strArr[0])));
            var head = nodes.Peek();

            for (int i = 1; i < strArr.Length; i++)
            {
                if (nodes.Count == 0)
                {
                    break;
                }

                var curr = nodes.Dequeue();
                if (curr != null)
                {
                    if (!strArr[i].Equals("null") && !String.IsNullOrEmpty(strArr[i]))
                    {
                        curr.left = new Node(Int32.Parse(strArr[i]));
                        nodes.Enqueue(curr.left);
                    }

                    i +=1;
                    if (i < strArr.Length && !strArr[i].Equals("null") && !String.IsNullOrEmpty(strArr[i]))
                    {
                        curr.right = new Node(Int32.Parse(strArr[i]));
                        nodes.Enqueue(curr.right);
                    }
                }
            }

            return head;
        }

        private static string RemoveTrailingNulls(string str)
        {
            int lastNullPosition = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i].Equals(',') && i < str.Length - 1)
                {
                    if (str[i + 1].Equals('n'))
                    {
                        lastNullPosition = i;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return str.Substring(0, lastNullPosition);
        }
    }

    public class Node
    {
        public int val { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int value)
        {
            val = value;
        }
    }
}