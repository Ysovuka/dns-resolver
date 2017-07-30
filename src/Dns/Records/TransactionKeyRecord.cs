using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class TransactionKeyRecord : IRecord
    {
        public string Algorithm { get; }
        public int Inception { get; }
        public int Expiration { get; }
        public short Mode { get; }
        public short Error { get; }
        public short KeySize { get; }
        public byte[] KeyData { get; }
        public short OtherSize { get; }
        public byte[] OtherData { get; }

        internal TransactionKeyRecord(Pointer pointer)
        {
            Algorithm = pointer.ReadDomain();
            Inception = pointer.ReadInt();
            Expiration = pointer.ReadInt();
            Mode = pointer.ReadShort();
            Error = pointer.ReadShort();
            KeySize = pointer.ReadShort();
            KeyData = pointer.ReadBytes(KeySize);
            OtherSize = pointer.ReadShort();
            OtherData = pointer.ReadBytes(OtherSize);
        }

        public override string ToString()
        {
            return $@"Algorithm: {Algorithm}
Inception: {Inception}
Expiration: {Expiration}
Mode: {Mode}
Error: {Error}";
        }
    }
}
