using NUnit.Framework;

namespace hw2Calculator.Test
{
    [TestFixture]
    class IStackTest
    {
        [TestCase]
        public void IsEmptyAfterPush()
        {
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            stack1.Push(9);
            stack2.Push(8);
            Assert.IsTrue(!(stack1.IsEmpty() && stack2.IsEmpty()));
        }

        [TestCase]
        public void PopAfterPush()
        {
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            stack1.Push(9);
            stack2.Push(8);
            Assert.IsTrue((stack1.Pop() == 9 && stack2.Pop() == 8));
        }

        [TestCase]
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

        [TestCase]
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