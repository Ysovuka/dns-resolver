using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class NimLoc : IDnsType
    {
        public int ToInt() => 32;
    }
}
