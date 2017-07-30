using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.OperationCodes
{
    internal class InverseQuery : IDnsOperationCode
    {
        public int ToInt() => 1;
    }
}
