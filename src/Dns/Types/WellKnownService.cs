using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class WellKnownService : IDnsType
    {
        public int ToInt() => 11;
    }
}
