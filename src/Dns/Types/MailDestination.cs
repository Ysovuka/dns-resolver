using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class MailDestination : IDnsType
    {
        public int ToInt() => 3;
    }
}
