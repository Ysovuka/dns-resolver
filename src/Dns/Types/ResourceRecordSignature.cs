using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class ResourceRecordSignature : IDnsType
    {
        public int ToInt() => 46;
    }
}
