using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    public interface INode
    {
        /// <summary>
        /// печатает, что находиться в узле
        /// </summary>
        public void Print();

        /// <summary>
        /// возвращает значение элемента, лежащего в узле
        /// </summary>
        public double Calculate();
    }
}