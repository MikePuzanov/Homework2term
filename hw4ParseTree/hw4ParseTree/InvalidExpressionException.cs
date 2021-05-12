using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// исключение для неправильных выражений6
    /// </summary>
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException()
        {
        }

        public InvalidExpressionException(string message)
        : base(message)
        {
        }
    }
}