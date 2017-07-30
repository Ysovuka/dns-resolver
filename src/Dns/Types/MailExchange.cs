using Dns.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class MailExchange : IDnsType
    {
        public int ToInt() => 15;
    }
}
