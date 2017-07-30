using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Types
{
    public class MailboxRename : IDnsType
    {
        public int ToInt() => 9;
    }
}
