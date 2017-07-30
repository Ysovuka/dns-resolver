using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class RouteThroughRecord : IRecord
    {
        public short Preference { get; }
        public string Domain { get; }

        internal RouteThroughRecord(Pointer pointer)
        {
            Preference = pointer.ReadShort();
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Preference: {Preference}
Domain: {Domain}";
        }
    }
}
