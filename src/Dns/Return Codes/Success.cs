using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal class Success : IDnsReturnCode
    {
        public int ToInt() => 0;
    }
}
