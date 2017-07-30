using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class AFSDatabaseServerRecord : IRecord
    {
        public ushort Subtype { get; }
        public string Host { get; }

        internal AFSDatabaseServerRecord(Pointer pointer)
        {
            Subtype = (ushort)pointer.ReadShort();
            Host = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}",
                Subtype,
                Host);
        }
    }
}
