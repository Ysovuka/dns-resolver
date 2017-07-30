using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class X400Pointer : IDnsType
    {
        public int ToInt() => 26;
    }
}
