using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class IPv6Address : IDnsType
    {
        public int ToInt() => 38;
    }
}
