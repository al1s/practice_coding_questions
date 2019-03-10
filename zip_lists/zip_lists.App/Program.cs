using System;
using System.Collections.Generic;
using System.Linq;

namespace zip_lists.App
{
    public class Zipper<T>
    {
        /// <summary>
        /// Zip lists together with interlaced
        /// </summary>
        /// <param name="inputLists">List of lists to be zipped</param>
        /// <returns>Zipped list</returns>
        public static List<T> Zip_lists(List<List<T>> inputLists)
        {
            if(inputLists.Count == 0)
            {
                throw new Exception("No elements provided in the input list");
            }
            var pointer = 0;
            List<T> resultList = new List<T>();
            List<int> inputListsLength = new List<int>();
            foreach (var item in inputLists)
            {
                inputListsLength.Add(item.Count);
            }
            int maxLength = inputListsLength.Max();
            while(pointer < maxLength)
            {
                foreach (var list in inputLists)
                {
                    if(list.Count > pointer)
                    {
                        resultList.Add(list[pointer]);
                    }
                }
                pointer += 1;
            }
            return resultList;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
