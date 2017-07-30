using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal class NotImplemented : IDnsReturnCode
    {
        public int ToInt() => 4;
    }
}
