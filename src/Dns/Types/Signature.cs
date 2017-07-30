using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class Signature : IDnsType
    {
        public int ToInt() => 24;
    }
}
