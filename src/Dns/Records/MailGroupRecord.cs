using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class MailGroupRecord : IRecord
    {
        public string Domain { get; }

        internal MailGroupRecord(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
