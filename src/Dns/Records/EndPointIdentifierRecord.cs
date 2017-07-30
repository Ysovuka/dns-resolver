using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class EndPointIdentifierRecord : IRecord
    {
        public byte[] Data { get; }

        internal EndPointIdentifierRecord(Pointer pointer)
        {
            ushort length = (ushort)pointer.ReadShort(-2);
            Data = new byte[length];
            Data = pointer.ReadBytes(length);
        }

        public override string ToString()
        {
            return "Not implemented.";
        }
    }
}
