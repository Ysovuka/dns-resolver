using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class GeographicLocationInformation : IDnsType
    {
        public int ToInt() => 27;
    }
}
