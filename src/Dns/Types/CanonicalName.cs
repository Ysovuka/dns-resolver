using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class CanonicalName : IDnsType
    {
        public int ToInt() => 5;
    }
}
