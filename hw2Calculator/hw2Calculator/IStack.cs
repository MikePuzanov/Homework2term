using System;
using System.Collections.Generic;
using System.Text;

namespace hw2Calculator
{
    interface IStack
    {
        void Push(double value);

        double Pop();

        bool IsEmpty();

        void DeleteStack();
    }
}