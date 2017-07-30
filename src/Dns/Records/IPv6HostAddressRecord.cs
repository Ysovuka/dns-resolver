using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dns.Records
{
    public class IPv6HostAddressRecord : IRecord
    {
        private IPAddress _ipAddress;
        public IPAddress IPAddress { get { return _ipAddress; } }

        internal IPv6HostAddressRecord(Pointer pointer)
        {
            IPAddress.TryParse(
                string.Format("{0:x}:{1:x}:{2:x}:{3:x}:{4:x}:{5:x}:{6:x}:{7:x}",
                pointer.ReadShort(),
                pointer.ReadShort(),
                pointer.ReadShort(),
                pointer.ReadShort(),
                pointer.ReadShort(),
                pointer.ReadShort(),
                pointer.ReadShort(),
                pointer.ReadShort()), out _ipAddress);
        }

        public override string ToString()
        {
            return IPAddress.ToString();
        }
    }
}
