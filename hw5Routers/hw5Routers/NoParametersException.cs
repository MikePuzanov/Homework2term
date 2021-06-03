using System;
using System.Collections.Generic;
using System.Text;

namespace Hw5Routers
{
    public class NoParametersException : Exception
    {
        public NoParametersException()
        {
        }

        public NoParametersException(string message)
        : base(message)
        {
        }
    }
}
