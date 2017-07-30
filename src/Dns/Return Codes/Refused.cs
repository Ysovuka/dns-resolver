using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal class Refused : IDnsReturnCode
    {
        public int ToInt() => 5;
    }
}
