using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace hw6MapFilterFold.Test
{
    public class Tests
    {
        private List<int> listInt;

        private List<string> listString;

        private List<char> listChar;

        [SetUp]
        public void Setup()
        {
            listInt = new List<int>() { 1, 2, 3 };
            listString = new List<string>() { "a", "b", "c" };
            listChar = new List<char>() { 'a', 'b', 'c' };
        }

        [Test]
        public void MapTest()
        {
            var resultList1 = new List<int>() { 2, 4, 6 };
            var list1 = Functions<int>.Map(listInt, x => x * 2);
            Assert.AreEqual(resultList1, list1);
            var resultList2 = new List<string>() { "aaaa", "baaa", "caaa" };
            var list2 = Functions<string>.Map(listString, x => x + "aaa");
            Assert.AreEqual(resultList2, list2);
            var resultList3 = new List<char>() { 'd', 'd', 'd' };
            var list3 = Functions<char>.Map(listChar, x => 'd');
            Assert.AreEqual(resultList3, list3);
        }

        [Test]
        public void FilterTest()
        {
            var resultList1 = new List<int>() { 2 };
            var list1 = Functions<int>.Filter(listInt,  y => y % 2 == 0 );
            Assert.AreEqual(resultList1, list1);
            var resultList2 = new List<string>() { "b" };
            var list2 = Functions<string>.Filter(listString, x => x == "b");
            Assert.AreEqual(resultList2, list2);
            var resultList3 = new List<char>() { };
            var list3 = Functions<char>.Filter(listChar, x => x == 'w');
            Assert.AreEqual(resultList3, list3);
        }
        

        [Test]
        public void FoldTest()
        {
            var fold1 = Functions<int>.Fold(listInt, 1, (acc, elem) => acc * elem);
            Assert.AreEqual(6, fold1);
            var fold2 = Functions<string>.Fold(listString, "w", (acc, elem) => acc + elem);
            Assert.AreEqual("wabc", fold2);
        }
    }
}