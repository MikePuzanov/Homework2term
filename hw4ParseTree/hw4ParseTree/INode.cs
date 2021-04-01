using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    public interface INode
    {
        /// <summary>
        /// 
        /// </summary>
        public void Print();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double Calculate();
    }
}