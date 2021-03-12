using System;
using System.Collections.Generic;
using System.Text;

namespace hw2Calculator
{
    class StackArray : IStack
    {
        private double[] stackElements;
        private int index;

        public StackArray()
        {
            stackElements = new double[5];
        }

        public void Push(double value)
        {
            if (index == stackElements.Length)
            {

            }
            stackElements[index] = value;
            index++;
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            index--;
            double delete = stackElements[index];
            return delete;
        }

        public bool IsEmpty()
        {
            return index == 0;
        }

        public void DeleteStack()
        {
            stackElements = new double[5];
            index = 0;
        }
    }
}