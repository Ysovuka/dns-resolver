using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class MailboxRenameRecord : IRecord
    {
        public string Domain { get; }

        internal MailboxRenameRecord(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
