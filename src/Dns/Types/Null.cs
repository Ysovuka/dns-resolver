using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class Null : IDnsType
    {
        public int ToInt() => 10;
    }
}
