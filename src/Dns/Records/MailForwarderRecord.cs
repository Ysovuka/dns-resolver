using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class MailForwarderRecord : IRecord
    {
        public string Domain { get; }

        internal MailForwarderRecord(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
