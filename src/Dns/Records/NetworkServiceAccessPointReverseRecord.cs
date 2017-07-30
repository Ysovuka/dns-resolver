using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class NetworkServiceAccessPointReverseRecord : IRecord
    {
        public string Owner { get; }

        internal NetworkServiceAccessPointReverseRecord(Pointer pointer)
        {
            Owner = pointer.ReadString();
        }

        public override string ToString()
        {
            return Owner;
        }
    }
}
