using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class X25PointerRecord : IRecord
    {
        public string Address { get; }

        internal X25PointerRecord(Pointer pointer)
        {
            Address = pointer.ReadString();
        }

        public override string ToString()
        {
            return Address;
        }
    }
}
