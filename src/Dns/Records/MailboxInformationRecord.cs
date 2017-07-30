using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class MailboxInformationRecord : IRecord
    {
        public string SenderDomain { get; }
        public string ErrorDomain { get; }

        internal MailboxInformationRecord(Pointer pointer)
        {
            SenderDomain = pointer.ReadDomain();
            ErrorDomain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Sender Domain: {SenderDomain}
Error Domain: {ErrorDomain}";
        }
    }
}
