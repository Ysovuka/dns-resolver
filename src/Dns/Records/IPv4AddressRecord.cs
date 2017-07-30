using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dns.Records
{
    /// <summary>
    /// (RFC1035 3.4.1)
    /// </summary>
    public class IPv4AddressRecord : IRecord
    {
        public IPAddress IPAddress { get; }

        internal IPv4AddressRecord(Pointer pointer)
        {
            IPAddress = IPAddress.Parse($"{pointer.ReadByte()}.{pointer.ReadByte()}.{pointer.ReadByte()}.{pointer.ReadByte()}");            
        }

        public override string ToString()
        {
            return IPAddress.ToString();
        }
    }
}
