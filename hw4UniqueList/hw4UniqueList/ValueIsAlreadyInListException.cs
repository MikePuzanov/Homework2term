using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4UniqueList
{
    /// <summary>
    /// исключение для unique list, когда значение уже содержиться в списке
    /// </summary>
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
