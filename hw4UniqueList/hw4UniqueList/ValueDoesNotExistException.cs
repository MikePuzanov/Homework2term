using System;
using System.Collections.Generic;
using System.Text;

namespace hw4UniqueList
{
    public class ValueDoesNotExistException : Exception
    {
        public ValueDoesNotExistException()
        {
        }

        public ValueDoesNotExistException(string message)
        : base(message)
        {
        }
    }
}
