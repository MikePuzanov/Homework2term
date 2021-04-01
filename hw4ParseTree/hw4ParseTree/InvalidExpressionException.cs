using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
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