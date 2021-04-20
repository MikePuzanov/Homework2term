using NUnit.Framework;

namespace hw2Calculator.Test
{
    [TestFixture]
    class IStackTest
    {
        [Test]
        public void IsEmptyAfterPush()
        {
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            stack1.Push(9);
            stack2.Push(8);
            Assert.IsTrue(!(stack1.IsEmpty() && stack2.IsEmpty()));
        }

        [Test]
        public void PopAfterPush()
        {
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            stack1.Push(9);
            stack2.Push(8);
            Assert.AreEqual(stack1.Pop(), 9);
            Assert.AreEqual(stack2.Pop(), 8);
        }

        [Test]
        public void CheckDeleteStack()
        {
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            stack1.Push(8);
            stack1.Push(9);
            stack2.Push(8);
            stack2.Push(9);
            stack1.DeleteStack();
            stack2.DeleteStack();
            Assert.IsTrue((stack1.IsEmpty() && stack2.IsEmpty()));
        }

        [Test]
        public void CheckIsEmpty()
        {
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            stack1.Push(9);
            stack2.Push(8);
            stack1.Pop();
            stack2.Pop();
            Assert.IsTrue((stack1.IsEmpty() && stack2.IsEmpty()));
        }
    }
}