using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// интерфейс узла в дереве разбора
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// печатает, что находится в узле
        /// </summary>
        public void Print();

        /// <summary>
        /// возвращает значение элемента, лежащего в узле
        /// </summary>
        public double Calculate();
    }
}