using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class KeyRecord : IRecord
    {
        public ushort Flags { get; }
        public byte Protocol { get; }
        public byte Algorithm { get; }
        public string PublicKey { get; }

        internal KeyRecord(Pointer pointer)
        {
            Flags = (ushort)pointer.ReadShort();
            Protocol = pointer.ReadByte();
            Algorithm = pointer.ReadByte();
            PublicKey = pointer.ReadString();
        }

        public override string ToString()
        {
            return $@"Flags: {Flags}
Protocol: {Protocol}
Algorithm: {Algorithm}
Public Key: {PublicKey}";
        }
    }
}
