using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    internal class NullType : IDnsType
    {
        public int ToInt() => -1;
    }
}
