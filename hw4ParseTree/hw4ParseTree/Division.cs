using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// класс для деления
    /// </summary>
    public class  Division : Operator
    {
        public override char Sign { get; }

        public Division(INode leftChild, INode rightChild)
        {
            Sign = '/';
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public override double Calculate()
        {
            if (Math.Abs(RightChild.Calculate()) < 0.000001)
            {
                throw new DivideByZeroException();
            }
            return LeftChild.Calculate() / RightChild.Calculate();
        }
    }
}