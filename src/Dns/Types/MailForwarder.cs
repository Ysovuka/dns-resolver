using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class MailForwarder : IDnsType
    {
        public int ToInt() => 4;
    }
}
