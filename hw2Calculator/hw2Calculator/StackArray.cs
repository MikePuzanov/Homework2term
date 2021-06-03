using System;
using System.Collections.Generic;
using System.Text;

namespace Hw2Calculator
{
    public class StackArray : IStack
    {
        private double[] stackElements;
        private int countNumbersInStack;

        public StackArray()
        {
            stackElements = new double[5];
        }

        public void Push(double value)
        {
            if (countNumbersInStack == stackElements.Length)
            {
                Array.Resize(ref stackElements, stackElements.Length * 2);
            }
            stackElements[countNumbersInStack] = value;
            countNumbersInStack++;
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            countNumbersInStack--;
            return stackElements[countNumbersInStack];
        }

        public bool IsEmpty()
            => countNumbersInStack == 0;

        public void ClearStack()
        {
            stackElements = new double[5];
            countNumbersInStack = 0;
        }
    }
}