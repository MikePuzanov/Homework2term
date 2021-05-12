using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// класс для сложения
    /// </summary>
    public class Addition : Operator
    {
        public override char Sign { get; }

        public Addition(INode leftChild, INode rightChild)
        {
            Sign = '+';
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public override double Calculate()
            => LeftChild.Calculate() + RightChild.Calculate();
    }
}