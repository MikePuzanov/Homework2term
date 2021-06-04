using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// класс синтаксического дерева, который представляет число
    /// </summary>
    class Operand : INode
    {
        private double Number;

        public Operand(double number)
            => Number = number;

        /// <summary>
        /// выводит число
        /// </summary>
        public void Print()
            => Console.Write($" {Number} ");

        /// <summary>
        /// считает значение
        /// </summary>
        public double Calculate()
            => Number;
    }
}