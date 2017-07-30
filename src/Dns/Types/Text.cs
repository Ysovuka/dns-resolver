using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class Text : IDnsType
    {
        public int ToInt() => 16;
    }
}
