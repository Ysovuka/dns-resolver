using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    /// <summary>
    /// (RFC1035 3.3.11)
    /// </summary>
    public class NameServerRecord : IRecord
    {
        public string Domain { get; }

        internal NameServerRecord(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
