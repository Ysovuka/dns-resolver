using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class IPSecKey : IDnsType
    {
        public int ToInt() => 45;
    }
}
