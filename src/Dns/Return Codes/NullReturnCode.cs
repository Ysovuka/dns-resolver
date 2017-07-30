using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.ReturnCodes
{
    internal class NullReturnCode : IDnsReturnCode
    {
        public int ToInt() => -1;
    }
}
