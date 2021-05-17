using NUnit.Framework;

namespace Hw2Calculator.Test
{
    [TestFixture]
    public class IStackTest
    {
        IStack stack1;
        IStack stack2;

        [SetUp]
        public void Setup()
        {
            stack1 = new StackList();
            stack2 = new StackArray();
            stack1.Push(9);
            stack2.Push(8);
        }

        [Test]
        public void IsEmptyAfterPush()
        {
            Assert.IsTrue(!(stack1.IsEmpty() && stack2.IsEmpty()));
        }

        [Test]
        public void PopAfterPush()
        {
            Assert.AreEqual(9, stack1.Pop());
            Assert.AreEqual(8, stack2.Pop());
        }

        [Test]
        public void CheckDeleteStack()
        {
            stack1.Push(8);
            stack1.Push(9);
            stack1.ClearStack();
            stack2.ClearStack();
            Assert.IsTrue((stack1.IsEmpty() && stack2.IsEmpty()));
        }

        [Test]
        public void CheckIsEmpty()
        {
            stack1.Pop();
            stack2.Pop();
            Assert.IsTrue((stack1.IsEmpty() && stack2.IsEmpty()));
        }
    }
}