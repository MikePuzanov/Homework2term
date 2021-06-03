using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// класс для вычитания
    /// </summary>
    public class Subtraction : Operator
    {
        public override char Sign => '-';

        public Subtraction(INode leftChild, INode rightChild)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public override double Calculate()
           => LeftChild.Calculate() - RightChild.Calculate();
    }
}
