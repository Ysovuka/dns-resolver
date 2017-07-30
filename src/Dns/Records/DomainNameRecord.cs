using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class DomainNameRecord : IRecord
    {
        public string Target { get; }

        internal DomainNameRecord(Pointer pointer)
        {
            Target = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Target;
        }
    }
}
