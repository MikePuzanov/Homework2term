using System;
using System.Collections.Generic;
using System.Text;

namespace hw5Routers
{
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
