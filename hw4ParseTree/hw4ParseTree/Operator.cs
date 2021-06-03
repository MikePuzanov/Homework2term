using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// Класс синтаксического дерва который представляет оператор
    /// </summary>
    public abstract class Operator : INode
    {
        public INode LeftChild { get; set; }

        public INode RightChild { get; set; }

        public virtual char Sign { get; }

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
