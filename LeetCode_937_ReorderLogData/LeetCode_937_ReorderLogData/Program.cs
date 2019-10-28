using System;
using System.Collections.Generic;

namespace LeetCode_937_ReorderLogData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logs = new[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            var sorted = LogSorter(logs);

            logs = new[] { "dig1 8 1 5 1", "dig1 8 1 5 1", "let3 art", "let2 art can", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            sorted = LogSorter(logs);
        }

        public static string[] LogSorter(string[] logs)
        {
            var digiLog = new List<string>();
            var letterLog = new List<string>();
            foreach (var log in logs)
            {
                var logIdEndPosition = log.IndexOf(' ');
                if (int.TryParse(log[logIdEndPosition + 1].ToString(), out _))
                {
                    digiLog.Add(log);
                }
                else
                {
                    letterLog.Add(log);
                }
            }
            var cmp = new LogComparer();
            letterLog.Sort(cmp);
            letterLog.AddRange(digiLog);
            return letterLog.ToArray();
        }
    }

    public class LogComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            var aIdEndPosition = a.IndexOf(' ');
            var bIdEndPosition = b.IndexOf(' ');
            var aData = a.Substring(aIdEndPosition);
            var bData = b.Substring(bIdEndPosition);
            var comparisonResult = String.Compare(aData, bData);
            return comparisonResult != 0
                ? comparisonResult
                : String.Compare(a.Substring(0, aIdEndPosition), b.Substring(0, bIdEndPosition));
        }
    }
}