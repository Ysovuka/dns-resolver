using System;
using System.Collections.Generic;
using System.Text;

namespace Dns
{
    /// <summary>
    /// Thrown when the server does not respond
    /// </summary>
    public class NoResponseException : Exception
    {
        public NoResponseException()
        {
            // no implementation
        }

        public NoResponseException(Exception innerException) : base(null, innerException)
        {
            // no implementation
        }

        public NoResponseException(string message, Exception innerException) : base(message, innerException)
        {
            // no implementation
        }
    }
}
