using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class EndpointIdentifier : IDnsType
    {
        public int ToInt() => 31;
    }
}
