using NUnit.Framework;
using System;

namespace Hw4ParseTree.Test
{
    public class Tests
    {
        private ParseTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new ParseTree();
        }

        [TestCase]
        public void TestAddition()
        {
            var str = "( + 2 3 )";
            tree.BuildTree(str);
            Assert.AreEqual(5, tree.Calculate());
        }

        [TestCase]
        public void TestSubtraction()
        {
            var str = "( - 2 3 )";
            tree.BuildTree(str);
            Assert.AreEqual(-1, tree.Calculate());
        }

        [TestCase]
        public void TestMultiplication()
        {
            var str = "( * 2 3 )";
            tree.BuildTree(str);
            Assert.AreEqual(6, tree.Calculate());
        }

        [TestCase]
        public void TestDivision()
        {
            var str = "( / 8 4 )";
            tree.BuildTree(str);
            Assert.AreEqual(2, tree.Calculate());
        }

        [TestCase]
        public void TestDoubleDivision()
        {
            var str = "( / 3 2 )";
            tree.BuildTree(str);
            Assert.AreEqual(1.5, tree.Calculate(), double.PositiveInfinity);
        }

        [TestCase]
        public void TestWithNegativeNumber()
        {
            var str = "( + 3 -2 )";
            tree.BuildTree(str);
            Assert.AreEqual(1, tree.Calculate());
        }

        [TestCase]
        public void TestDivisionByZero()
        {
            var str = "( / 8 0 )";
            tree.BuildTree(str);
            Assert.Throws<DivideByZeroException>(() => tree.Calculate());
        }

        [TestCase]
        public void TestNotCorrectExpression()
        {
            var str = "( / 8 )";
            Assert.Throws<InvalidExpressionException>(() => tree.BuildTree(str));
        }

        [TestCase]
        public void TestTaskExpression()
        {
            var str = "( * ( + 1 1 ) 2 )";
            tree.BuildTree(str);
            Assert.AreEqual(4, tree.Calculate());
        }
    }
}