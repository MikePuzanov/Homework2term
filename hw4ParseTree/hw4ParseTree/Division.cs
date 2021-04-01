using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    public class  Division : Operator
    {
        public override string Sign { get; }

        public Division(string sign, INode leftChild, INode rightChild)
        {
            Sign = sign;
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