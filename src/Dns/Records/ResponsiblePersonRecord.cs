using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class ResponsiblePersonRecord : IRecord
    {
        public string MailboxDomain { get; }
        public string TextDomain { get; }

        internal ResponsiblePersonRecord(Pointer pointer)
        {
            MailboxDomain = pointer.ReadDomain();
            TextDomain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Mailbox Domain: {MailboxDomain}
Text Domain: {TextDomain}";
        }
    }
}
