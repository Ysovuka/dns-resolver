using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class X400Pointer : IRecord
    {
        public short Preference { get; }
        public string Map822 { get; }
        public string MapX400 { get; }

        internal X400Pointer(Pointer pointer)
        {
            Preference = pointer.ReadShort();
            Map822 = pointer.ReadDomain();
            MapX400 = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Preference: {Preference}
822: {Map822}
x400: {MapX400}";
        }
    }
}
