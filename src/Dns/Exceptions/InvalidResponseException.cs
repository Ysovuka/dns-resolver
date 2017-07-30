using System;
using System.Collections.Generic;
using System.Text;

namespace Dns
{
    public class InvalidResponseException : System.Exception
    {
        public InvalidResponseException()
        {
            // no implementation
        }

        public InvalidResponseException(Exception innerException) : base(null, innerException)
        {
            // no implementation
        }

        public InvalidResponseException(string message, Exception innerException) : base(message, innerException)
        {
            // no implementation
        }
    }
}
