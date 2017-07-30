using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class TransactionSignatureRecord : IRecord
    {
        public string Algorithm { get; }
        public long TimeSigned { get; }
        public short Fudge { get; }
        public short MacSize { get; }
        public byte[] Mac { get; }
        public short Id { get; }
        public short Error { get; }
        public short OtherLength { get; }
        public byte[] OtherData { get; }

        internal TransactionSignatureRecord(Pointer pointer)
        {
            Algorithm = pointer.ReadDomain();
            TimeSigned = pointer.ReadInt() << 32 | pointer.ReadInt();
            Fudge = pointer.ReadShort();
            MacSize = pointer.ReadShort();
            Mac = pointer.ReadBytes(MacSize);
            Id = pointer.ReadShort();
            Error = pointer.ReadShort();
            OtherLength = pointer.ReadShort();
            OtherData = pointer.ReadBytes(OtherLength);
        }

        public override string ToString()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(TimeSigned);
            string printDate = $"{dateTime.ToString("d")} {dateTime.ToString("t")}";
            return $@"Algorithm: {Algorithm}
Time Signed: {dateTime}
Fudge: {Fudge}
Id: {Id}
Error: {Error}";
        }
    }
}
