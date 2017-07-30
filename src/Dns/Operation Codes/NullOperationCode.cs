using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.OperationCodes
{
    internal class NullOperationCode : IDnsOperationCode
    {
        public int ToInt() => -1;
    }
}
