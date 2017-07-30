using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal class Other : IDnsReturnCode
    {
        public int ToInt() => 6;
    }
}
