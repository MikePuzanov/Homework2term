using System;
using System.Collections.Generic;

namespace Test2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>() { "abc", "aa", "bb", "zv", "fe", "qwe", "123" };
            BubbleSort.Sort(list, new CompareStringInDescendingOrder());
            for (int i = 0; i < list.Count; ++i)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
