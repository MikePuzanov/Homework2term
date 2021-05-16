using NUnit.Framework;
using System;

namespace hw4UniqueList.Test
{
    public class Tests
    {
        private List list;

        [SetUp]
        public void Setup()
        {
            list = new List();
            list.Insert(0, 2);
            list.Insert(1, 4);
            list.Insert(2, 7);
            list.Insert(3, 8);
            list.Insert(2, 6);
            list.Insert(1, 3);
            list.Insert(0, 1);
            list.Insert(4, 5);
        }

        [TestCase]
        public void TestInsert()
        {
            for (int i = 1; i < 9; ++i)
            {
                Assert.AreEqual(i, list.GetValueByIndex(i));
            }
        }

        [TestCase]
        public void TestDeleteByIndex()
        {
            list.DeleteByIndex(2);
            list.DeleteByIndex(7);
            list.DeleteByIndex(1);
            Assert.IsFalse(list.Contains(2));
            Assert.IsFalse(list.Contains(8));
            Assert.IsFalse(list.Contains(1));
        }

        [TestCase]
        public void TestDeleteByIndexException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.DeleteByIndex(12));
        }

        [TestCase]
        public void TestDeleteByValueException()
        {
            Assert.Throws<ValueDoesNotExistException>(() => list.DeleteByValue(12));
        }

        [TestCase]
        public void TestDeleteByValue()
        {
            list.DeleteByValue(2);
            list.DeleteByValue(8);
            list.DeleteByValue(1);
            Assert.IsFalse(list.Contains(2) || list.Contains(8) || list.Contains(1));
        }

        [TestCase]
        public void TestChangeByIndexIndexException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.ChangeByIndex(12, 1));
        }

        [TestCase]
        public void TestChangeByIndex()
        {
            for (int i = 1; i < 9; ++i)
            {
                list.ChangeByIndex(i, i + 10);
            }
            for (int i = 1; i < 9; ++i)
            {
                Assert.AreEqual(i + 10, list.GetValueByIndex(i));
            }
        }

        [TestCase]
        public void TestGetSize()
        {
            Assert.AreEqual(list.GetSize(), 8);
        }

        [TestCase]
        public void TestIsEmpty()
        {
            for (int i = 1; i < 9; ++i)
            {
                list.DeleteByValue(i);
            }
            Assert.IsTrue(list.IsEmpty());
        }
    }
}