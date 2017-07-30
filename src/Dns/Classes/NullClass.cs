using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Classes
{
    internal class NullClass : IDnsClass
    {
        public int ToInt() => -1;
    }
}
