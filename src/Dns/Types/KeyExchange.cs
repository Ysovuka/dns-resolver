using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class KeyExchange : IDnsType
    {
        public int ToInt() => 36;
    }
}
