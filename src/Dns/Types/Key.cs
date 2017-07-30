using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class Key : IDnsType
    {
        public int ToInt() => 25;
    }
}
