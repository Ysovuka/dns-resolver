using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class WellKnownServiceRecord : IRecord
    {
        public string Address { get; }
        public int Protocol { get; }
        public byte[] Bitmap { get; }

        internal WellKnownServiceRecord(Pointer pointer)
        {
            short length = pointer.ReadShort(-2);
            Address = $"{pointer.ReadByte()}.{pointer.ReadByte()}.{pointer.ReadByte()}.{pointer.ReadByte()}";
            Protocol = pointer.ReadByte();
            length -= 5;
            Bitmap = new byte[length];
            Bitmap = pointer.ReadBytes(length);
        }
        public override string ToString()
        {
            return $@"Address: {Address}
Protocol: {Protocol}";
        }
    }
}
