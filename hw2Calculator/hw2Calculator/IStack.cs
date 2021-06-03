using System;
using System.Collections.Generic;
using System.Text;

namespace Hw2Calculator
{
    public interface IStack
    {
        void Push(double value);

        double Pop();

        bool IsEmpty();

        void ClearStack();
    }
}