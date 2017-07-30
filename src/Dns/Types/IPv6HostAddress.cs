using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class IPv6HostAddress : IDnsType
    {
        public int ToInt() => 28;
    }
}
