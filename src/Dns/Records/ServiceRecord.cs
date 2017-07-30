using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class ServiceRecord : IRecord
    {
        public short Priority { get; }
        public short Weight { get; }
        public short Port { get; }
        public string Domain { get; }

        internal ServiceRecord(Pointer pointer)
        {
            Priority = pointer.ReadShort();
            Weight = pointer.ReadShort();
            Port = pointer.ReadShort();
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Priority: {Priority}
Weight: {Weight}
Port: {Port}
Domain: {Domain}";
        }
    }
}
