using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class StateOfAuthority : IDnsType
    {
        public int ToInt() => 6;
    }
}
