using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    public abstract class Operator : INode
    {
        public INode LeftChild { get; set; }

        public INode RightChild { get; set; }

        public virtual string Sign { get; }

        public void Print()
        {
            Console.Write("(");
            LeftChild.Print();
            Console.Write(Sign);
            RightChild.Print();
            Console.Write(")");
        }
        public abstract double Calculate();

    }
}
