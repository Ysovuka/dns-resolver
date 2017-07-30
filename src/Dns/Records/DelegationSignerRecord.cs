using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class DelegationSignerRecord : IRecord
    {
        public ushort KeyTag { get; }
        public byte Algorithm { get; }
        public byte DigestType { get; }
        public byte[] Digest { get; }

        internal DelegationSignerRecord(Pointer pointer)
        {
            ushort length = (ushort)pointer.ReadShort(-2);
            KeyTag = (ushort)pointer.ReadShort();
            Algorithm = pointer.ReadByte();
            DigestType = pointer.ReadByte();
            length -= 4;
            Digest = new byte[length];
            Digest = pointer.ReadBytes(length);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int index = 0; index < Digest.Length; index++)
            {
                stringBuilder.AppendFormat("{0:x2}", Digest[index]);
            }
            return $@"KeyTag: {KeyTag}
Algorithm: {Algorithm}
DigestType: {DigestType}
Digest:
    {stringBuilder.ToString()}";
        }
    }
}
