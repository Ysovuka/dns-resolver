using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.OperationCodes
{
    internal class StatusRequest : IDnsOperationCode
    {
        public int ToInt() => 2;
    }
}
