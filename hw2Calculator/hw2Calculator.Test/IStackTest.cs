using NUnit.Framework;
using System.Collections.Generic;

namespace Hw2Calculator.Test
{
    [TestFixture]
    public class IStackTest
    {
        [TestCaseSource(nameof(Stacks))]
        public void IsEmptyAfterPush(IStack stack)
        {
            stack.Push(9);
            Assert.IsTrue(!(stack.IsEmpty()));
        }

        [TestCaseSource(nameof(Stacks))]
        public void PopAfterPush(IStack stack)
        {
            stack.Push(9);
            Assert.AreEqual(9, stack.Pop());
        }

        [TestCaseSource(nameof(Stacks))]
        public void CheckDeleteStack(IStack stack)
        {
            stack.Push(9);
            stack.Push(8);
            stack.Push(9);
            stack.ClearStack();
            Assert.IsTrue((stack.IsEmpty()));
        }

        [TestCaseSource(nameof(Stacks))]
        public void CheckIsEmpty(IStack stack)
        {
            stack.Push(9);
            stack.Pop();
            Assert.IsTrue((stack.IsEmpty()));
        }

        private static IEnumerable<TestCaseData> Stacks
            => new TestCaseData[]
            {
                new TestCaseData(new StackList()),
                new TestCaseData(new StackArray()),
            };
    }
}