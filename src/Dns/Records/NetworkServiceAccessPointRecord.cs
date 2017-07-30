using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class NetworkServiceAccessPointRecord : IRecord
    {
        public ushort Length { get; }
        public byte[] Address { get; }

        internal NetworkServiceAccessPointRecord(Pointer pointer)
        {
            Length = (ushort)pointer.ReadShort();
            Address = pointer.ReadBytes(Length);
        }

        public override string ToString()
        {
            return string.Format("{0:X}.{1:X}.{2:X}.{3:X}.{4:X}.{5:X}.{6:X}.{7:X}.{8:X}",
                Address[0],
                Address[1] << 8 | Address[2],
                Address[3],
                Address[4] << 16 | Address[5] << 8 | Address[6],
                Address[7] << 8 | Address[8],
                Address[9] << 8 | Address[10],
                Address[11] << 8 | Address[12],
                Address[13] << 16 | Address[14] << 8 | Address[15],
                Address[16] << 16 | Address[17] << 8 | Address[18],
                Address[19]);
        }
    }
}
