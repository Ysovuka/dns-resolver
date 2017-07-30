using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal class ServerFailure : IDnsReturnCode
    {
        public int ToInt() => 2;
    }
}
