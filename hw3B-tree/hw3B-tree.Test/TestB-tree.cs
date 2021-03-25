using NUnit.Framework;

namespace hw3B_tree.Test
{
    public class Tests
    {
        private BTree tree = new BTree(2);

        [SetUp]
        public void Setup()
        {
            tree.Insert("1", "a");
            tree.Insert("2", "b");
            tree.Insert("3", "c");
            tree.Insert("4", "d");
            tree.Insert("5", "e");
            tree.Insert("6", "f");
            tree.Insert("7", "g");
            tree.Insert("8", "h");
        }

        [TestCase]
        public void CheckInsert1()
        {
            Assert.IsTrue(tree.IsConsist("6"));
        }

        [TestCase]
        public void CheckInsert2()
        {
            Assert.IsTrue(tree.IsConsist("8"));
        }

        [TestCase]
        public void CheckGetValue1()
        {
            Assert.IsTrue(tree.GetValue("5") == "e");
        }

        [TestCase]
        public void CheckGetValue2()
        {
            Assert.IsTrue(tree.GetValue("8") == "h");
        }
    }
}