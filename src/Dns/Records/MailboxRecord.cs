using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class MailboxRecord : IRecord
    {
        public string Domain { get; }

        internal MailboxRecord(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
