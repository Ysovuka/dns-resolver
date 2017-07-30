using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class DomainName : IDnsType
    {
        public int ToInt() => 39;
    }
}
