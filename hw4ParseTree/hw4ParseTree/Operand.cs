using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    class Operand : INode
    {
        public double Number { get; set; }

        public Operand(double number)
        {
            Number = number;
        }

        public void Print()
        {
            Console.Write($" {Number} ");
        }

        public double Calculate()
            => Number;
    }
}