using NUnit.Framework;

namespace Hw3B_tree.Test
{
    public class Tests
    {
        private BTree tree;

        public BTree Setup(int MinimumDegreeOfTree)
        {
            tree = new BTree(MinimumDegreeOfTree);
            for (int i = 1; i < 19; ++i)
            {
                tree.Insert(i.ToString(), i.ToString());

            }
            return tree;
        }

        [TestCase]
        public void CheckInsert()
        {
            var tree = Setup(2);
            for (int i = 1; i <= 18; ++i)
            {
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

        [TestCase]
        public void CheckGetValue()
        {
            var tree = Setup(2);
            for (int i = 1; i <= 18; ++i)
            {
                Assert.IsTrue(tree.GetValue(i.ToString()) == i.ToString());
            }
        }
        
        [TestCase]
        public void CheckChangeValueByKey()
        {
            var tree = Setup(2);
            tree.ChangeValueByKey("5", "ololo");
            Assert.IsTrue(tree.GetValue("5") == "ololo");
        }
        
        [TestCase]
        public void CheckDeleteFromRoot()
        {
            var tree = Setup(2);
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

        [TestCase]
        public void CheckDeleteFromLeaf()
        {
            var tree = Setup(2);
            tree.Delete("5");
            for (int i = 1; i <= 18; ++i)
            {
                if (i == 5)
                {
                    Assert.IsFalse(tree.IsExists(i.ToString()));
                    continue;
                }
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

        [TestCase]
        public void CheckDeleteFromNotLeafWithChangeRoot()
        {
            var tree = Setup(2);
            tree.Delete("6");
            for (int i = 1; i <= 18; ++i)
            {
                if (i == 6)
                {
                    Assert.IsFalse(tree.IsExists(i.ToString()));
                    continue;
                }
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

        [TestCase]
        public void CheckDeleteFromLeafWithChangeValueInLeafs()
        {
            var tree = Setup(2);
            tree.Delete("15");
            for (int i = 1; i <= 18; ++i)
            {
                if (i == 15)
                {
                    Assert.IsFalse(tree.IsExists(i.ToString()));
                    continue;
                }
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

        [TestCase]
        public void CheckInsertWithAnotherDegree()
        {
            var tree = Setup(4);
            for (int i = 1; i <= 18; ++i)
            {
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

        [TestCase]
        public void CheckGetValueWithAnotherDegree()
        {
            var tree = Setup(4);
            for (int i = 1; i <= 18; ++i)
            {
                Assert.IsTrue(tree.GetValue(i.ToString()) == i.ToString());
            }
        }

        [TestCase]
        public void CheckChangeValueByKeyWithAnotherDegree()
        {
            var tree = Setup(4);
            tree.ChangeValueByKey("5", "ololo");
            Assert.IsTrue(tree.GetValue("5") == "ololo");
        }

        [TestCase]
        public void CheckDeleteFromRootWithAnotherDegree()
        {
            var tree = Setup(4);
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

        [TestCase]
        public void CheckDeleteFromLeafWithMergeLefsWithAnotherDegree()
        {
            var tree = Setup(4);
            tree.Delete("2");
            for (int i = 1; i <= 18; ++i)
            {
                if (i == 2)
                {
                    Assert.IsFalse(tree.IsExists(i.ToString()));
                    continue;
                }
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }

        [TestCase]
        public void CheckDeleteFromLeafWithChangeValueInLeafsWithAnotherDegree()
        {
            var tree = Setup(4);
            tree.Delete("10");
            for (int i = 1; i <= 18; ++i)
            {
                if (i == 10)
                {
                    Assert.IsFalse(tree.IsExists(i.ToString()));
                    continue;
                }
                Assert.IsTrue(tree.IsExists(i.ToString()));
            }
        }
    }
}