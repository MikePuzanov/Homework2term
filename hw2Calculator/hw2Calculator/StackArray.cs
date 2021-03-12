using System;
using System.Collections.Generic;
using System.Text;

namespace hw2Calculator
{
    class StackArray : IStack
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
            double delete = stackElements[countNumbersInStack];
            return delete;
        }

        public bool IsEmpty()
        {
            return countNumbersInStack == 0;
        }

        public void DeleteStack()
        {
            stackElements = new double[5];
            countNumbersInStack = 0;
        }
    }
}