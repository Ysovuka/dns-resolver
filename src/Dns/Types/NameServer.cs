using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class NameServer : IDnsType
    {
        public int ToInt() => 2;
    }
}
