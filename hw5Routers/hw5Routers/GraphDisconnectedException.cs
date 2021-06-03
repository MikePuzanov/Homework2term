using System;
using System.Collections.Generic;
using System.Text;

namespace Hw5Routers
{
    /// <summary>
    /// Исключение, когда граф несвязанный
    /// </summary>
    public class GraphDisconnectedException : Exception
    { 
        public GraphDisconnectedException()
        {
        }

        public GraphDisconnectedException(string message)
        : base(message)
        {
        }
    }
}
