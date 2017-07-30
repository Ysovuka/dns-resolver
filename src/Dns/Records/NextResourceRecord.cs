using Dns.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class NextResourceRecord : IRecord
    {
        public string Domain { get; }
        public byte[] Bitmap { get; }

        internal NextResourceRecord(Pointer pointer)
        {
            ushort length = (ushort)pointer.ReadShort(-2);
            Domain = pointer.ReadDomain();
            length -= (ushort)pointer.Position;
            Bitmap = new byte[length];
            Bitmap = pointer.ReadBytes(length);
        }

        private bool IsSet(int bitNr)
        {
            int @byte = (int)(bitNr / 8);
            int offset = (bitNr % 8);
            byte b = Bitmap[@byte];
            int test = 1 << offset;
            if ((b & test) == 0)
                return false;

            return true;
        }

        public override string ToString()
        {
            return Domain;
        }
    }
}
