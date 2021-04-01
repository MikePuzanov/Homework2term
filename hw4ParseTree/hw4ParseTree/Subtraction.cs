using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    public class Subtraction : Operator
    {
        public override string Sign { get;  }

        public Subtraction(string sign, INode leftChild, INode rightChild)
        {
            Sign = sign;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public override double Calculate()
           => LeftChild.Calculate() - RightChild.Calculate();
    }
}
