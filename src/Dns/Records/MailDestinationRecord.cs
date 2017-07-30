using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class MailDestinationRecord : IRecord
    {
        public string Domain { get; }

        internal MailDestinationRecord(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
