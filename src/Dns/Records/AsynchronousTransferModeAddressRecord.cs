using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class AsynchronousTransferModeAddressRecord : IRecord
    {
        public byte[] Data { get; }

        internal AsynchronousTransferModeAddressRecord(Pointer pointer)
        {
            ushort length = (ushort)pointer.ReadShort(-2);
            Data = pointer.ReadBytes(length);
        }

        public override string ToString()
        {
            return "Not implemented.";
        }
    }
}
