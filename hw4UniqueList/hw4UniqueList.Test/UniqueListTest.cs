using NUnit.Framework;
using System;

namespace hw4UniqueList.Test
{
    class UniqueListTest
    {
        private UniqueList list;

        [SetUp]
        public void Setup()
        {
            list = new UniqueList();
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
        public void TestInsertValueAgain()
        {
            Assert.Throws<ValueIsAlreadyInListException>(() => list.Insert(2, 3));
        }

        [TestCase]
        public void TestInsert()
        {
            list.Insert(3, 12);
            Assert.IsTrue(list.Contains(12));
        }

        [TestCase]
        public void TestDeleteByValueException()
        {
            Assert.Throws<ValueDoesNotExistException>(() => list.DeleteByValue(12));
        }

        [TestCase]
        public void TestDeleteByValue()
        {
            list.DeleteByValue(6);
            Assert.IsFalse(list.Contains(6));
        }

        [TestCase]
        public void TestDeleteByIndexException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.DeleteByIndex(12));
        }

        [TestCase]
        public void TestDeleteByIndex()
        {
            list.DeleteByValue(3);
            Assert.IsFalse(list.Contains(3));
        }

        [TestCase]
        public void TestChangeByIndexIndexException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.ChangeByIndex(12, 1));
        }

        [TestCase]
        public void TestChangeByIndexValueException()
        {
            Assert.Throws<ValueIsAlreadyInListException>(() => list.ChangeByIndex(3, 5));
        }
    }
}
