using System.Collections.Generic;
using System.Linq;

namespace LeetCode_76_MinimumWindowsSubstring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        public static string MinWindow(string s, string t)
        {
            var distance = new Dictionary<string, int>();
            var position = new Dictionary<char, int>();
            var tSet = new HashSet<char>(t.ToCharArray());
            for (int i = 0; i < s.Length; i++)
            {
                if (tSet.Contains(s[i]))
                {
                    foreach (var pair in distance.Keys.ToList())
                    {
                        if (pair.Contains(s[i]))
                        {
                        var opp = pair.Replace(s[i].ToString(), string.Empty)[0];
                            if (i - position[opp] < distance[$"{s[i]}{opp}"])
                            {
                                distance[$"{s[i]}{opp}"] = i - position[opp];
                                distance[opp + s[i]] = i - position[opp];
                                position[s[i]] = i;
                            }
                        }
                    }
                }
            }
        }
    }
}