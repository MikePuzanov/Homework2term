using System;
using System.Collections.Generic;

namespace hw6MapFilterFold
{
    class Program
    {
        static void Main(string[] args)
        {
            var listInt = new List<int>() { 1, 2, 3 };
            var resultList1 = new List<int>() { 2, 4, 6 };
            var list1 = Functions<int>.Map(listInt, x => x * 2);

            var listString = new List<string>() { "a", "b", "c" };
            var resultList2 = new List<string>() { "aaaa", "baaa", "caaa" };
            var list2 = Functions<string>.Map(listString, x => x + "aaa");

            var listChar = new List<char>() { 'a', 'b', 'c' };
            var resultList3 = new List<char>() { 'd', 'd', 'd' };
            var list3 = Functions<char>.Map(listChar, x => 'd');

        }
    }
}