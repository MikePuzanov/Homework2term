using System;
using System.Collections.Generic;
using System.Text;

namespace Hw2Calculator
{
    public class StackList : IStack
    {
        private class StackElement
        {
            public double value;
            public StackElement next;
        }

        private StackElement head;

        public void Push(double value)
            => head = new StackElement() { value = value, next = head };

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            double answer = head.value;
            head = head.next;
            return answer;
        }

        public bool IsEmpty()
            => head == null;

        public void ClearStack()
            => head = null;
    }
}