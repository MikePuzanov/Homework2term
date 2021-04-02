using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    public class Multiplication : Operator
    {
        public override char Sign { get; }

        public Multiplication(char sign, INode leftChild, INode rightChild)
        {
            Sign = sign;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public override double Calculate()
           => LeftChild.Calculate() * RightChild.Calculate();
    }
}