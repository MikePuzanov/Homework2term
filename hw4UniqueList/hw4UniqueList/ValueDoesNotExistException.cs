using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4UniqueList
{
    /// <summary>
    /// исключение для удаления элемента из списка, когда значение не содержиться в списке
    /// </summary>
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
