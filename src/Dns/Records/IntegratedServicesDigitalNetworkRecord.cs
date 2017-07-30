using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class IntegratedServicesDigitalNetworkRecord : IRecord
    {
        public string Address { get; }
        public string SubAddress { get; }

        internal IntegratedServicesDigitalNetworkRecord(Pointer pointer)
        {
            Address = pointer.ReadString();
            SubAddress = pointer.ReadString();
        }

        public override string ToString()
        {
            return $@"Address: {Address}
SubAddress: {SubAddress}";
        }
    }
}
