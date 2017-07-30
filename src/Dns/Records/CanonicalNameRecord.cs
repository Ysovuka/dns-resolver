using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class CanonicalNameRecord : IRecord
    {
        public string Name { get; }
        internal CanonicalNameRecord(Pointer pointer)
        {
            Name = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
