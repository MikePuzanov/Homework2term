using System;
using System.Collections.Generic;
using System.Text;

namespace hw4UniqueList
{
    public class ValueIsAlreadyInListException : Exception
    {
        public ValueIsAlreadyInListException()
        {
        }

        public ValueIsAlreadyInListException(string message)
        : base(message)
        {
        }
    }
}
