using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class PointerRecord : IRecord
    {
        public string Domain { get; }

        internal PointerRecord(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
