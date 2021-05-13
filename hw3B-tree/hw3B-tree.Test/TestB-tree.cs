using NUnit.Framework;

namespace Hw3B_tree.Test
{
    public class Tests
    {
        private BTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new BTree(2);
            tree.Insert("1", "1");
            tree.Insert("2", "2");
            tree.Insert("3", "3");
            tree.Insert("4", "4");
            tree.Insert("5", "5");
            tree.Insert("6", "6");
            tree.Insert("7", "7");
            tree.Insert("8", "8");
            tree.Insert("9", "9");
            tree.Insert("10", "10");
            tree.Insert("11", "11");
            tree.Insert("12", "12");
            tree.Insert("13", "13");
            tree.Insert("14", "14");
            tree.Insert("15", "15");
            tree.Insert("16", "16");
            tree.Insert("17", "17");
            tree.Insert("18", "18");
        }

        [TestCase]
        public void CheckInsert()
        {
            for (int i = 1; i <= 18; ++i)
            {
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

        [TestCase]
        public void CheckGetValue()
        {
            for (int i = 1; i <= 18; ++i)
            {
                Assert.IsTrue(tree.GetValue(i.ToString()) == i.ToString());
            }
        }
        
        [TestCase]
        public void CheckChangeValueByKey()
        {
            tree.ChangeValueByKey("5", "ololo");
            Assert.IsTrue(tree.GetValue("5") == "ololo");
        }
        
        [TestCase]
        public void CheckDelete()
        {
            tree.Delete("8");
            for (int i = 1; i <= 18; ++i)
            {
                if (i == 8)
                {
                    Assert.IsFalse(tree.IsExists(i.ToString()));
                    continue;
                }
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

    }
}