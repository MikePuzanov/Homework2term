using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// класс для умножения
    /// </summary>
    public class Multiplication : Operator
    {
        public override char Sign => '*';

        public Multiplication(INode leftChild, INode rightChild)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public override double Calculate()
           => LeftChild.Calculate() * RightChild.Calculate();
    }
}