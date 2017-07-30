using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class NameAuthorityPointer : IDnsType
    {
        public int ToInt() => 35;
    }
}
