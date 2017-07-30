using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal class NameError : IDnsReturnCode
    {
        public int ToInt() => 3;
    }
}
