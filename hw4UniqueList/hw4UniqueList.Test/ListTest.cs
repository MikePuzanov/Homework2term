using NUnit.Framework;

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
            Assert.IsFalse(list.IsConsist(2) || list.IsConsist(8) || list.IsConsist(1));
        }

        [TestCase]
        public void TestDeleteByValue()
        {
            list.DeleteByValue(2);
            list.DeleteByValue(8);
            list.DeleteByValue(1);
            Assert.IsFalse(list.IsConsist(2) || list.IsConsist(8) || list.IsConsist(1));
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
    }
}