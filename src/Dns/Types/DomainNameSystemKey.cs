using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class DomainNameSystemKey : IDnsType
    {
        public int ToInt() => 48;
    }
}
