using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class Certificate : IDnsType
    {
        public int ToInt() => 37;
    }
}
