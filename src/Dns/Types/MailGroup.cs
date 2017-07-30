using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class MailGroup : IDnsType
    {
        public int ToInt() => 8;
    }
}
