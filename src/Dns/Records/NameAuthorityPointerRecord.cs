using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class NameAuthorityPointerRecord : IRecord
    {
        public short Order { get; }
        public short Preference { get; }
        public string Flags { get; }
        public string Services { get; }
        public string RegularExpression { get; }
        public string Replacement { get; }

        internal NameAuthorityPointerRecord(Pointer pointer)
        {
            Order = pointer.ReadShort();
            Preference = pointer.ReadShort();
            Flags = pointer.ReadString();
            Services = pointer.ReadString();
            RegularExpression = pointer.ReadString();
            Replacement = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Order: {Order}
Preference: {Preference}
Flags: {Flags}
Services: {Services}
Regular Expression: {RegularExpression}
Replacement: {Replacement}";
        }
    }
}
