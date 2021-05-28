using NUnit.Framework;
using System.Collections.Generic;

namespace Test2._1.Test
{
    public class Tests
    {
        private List<int> listInt;

        private List<string> listString;

        [SetUp]
        public void Setup()
        {
            listInt = new List<int>() { 23 , 11, 13, 43, 12, 4, 32, 1 };
            listString = new List<string>() { "abc", "aa", "bb",  "zv", "fe", "qwe", "123" };
        }

        [Test]
        public void TestForInt()
        {
            var listCheck = new List<int>() { 43, 32, 23, 13, 12, 11, 4, 1 };
            BubbleSort.Sort(listInt, new CompareIntInDescendingOrder());
            for (int i = 0; i < listInt.Count; ++i)
            {
                Assert.AreEqual(listInt[i], listCheck[i]);
            }
        }

        [Test]
        public void TestForString()
        {
            BubbleSort.Sort(listString, new CompareStringInDescendingOrder());
            var listCheck = new List<string>() { "zv", "qwe", "fe", "bb", "abc", "aa", "123" };
            for (int i = 0; i < listString.Count; ++i)
            {
                Assert.AreEqual(listString[i], listCheck[i]);
            }
        }
    }
}