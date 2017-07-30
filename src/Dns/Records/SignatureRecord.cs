using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class SignatureRecord : IRecord
    {
        public short TypeCovered { get; }
        public byte Algorithm { get; }
        public byte Labels { get; }
        public int Ttl { get; }
        public int Expiration { get; }
        public int Inception { get; }
        public short KeyTag { get; }
        public string Domain { get; }
        public string Signature { get; }

        internal SignatureRecord(Pointer pointer)
        {
            TypeCovered = pointer.ReadShort();
            Algorithm = pointer.ReadByte();
            Labels = pointer.ReadByte();
            Ttl = pointer.ReadInt();
            Expiration = pointer.ReadInt();
            Inception = pointer.ReadInt();
            KeyTag = pointer.ReadShort();
            Domain = pointer.ReadDomain();
            Signature = pointer.ReadString();
        }

        public override string ToString()
        {
            return $@"Type Covered: {TypeCovered}
Algorithm: {Algorithm}
Labels: {Labels}
Ttl: {Ttl}
Expiration: {Expiration}
Inception: {Inception}
Key Tag: {KeyTag}
Domain: {Domain}
Signature: {Signature}";
        }
    }
}
