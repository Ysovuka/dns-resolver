using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class HostInformationRecord : IRecord
    {
        public string Cpu { get; }
        public String OperatingSystem { get; }

        internal HostInformationRecord(Pointer pointer)
        {
            Cpu = pointer.ReadString();
            OperatingSystem = pointer.ReadString();
        }

        public override string ToString()
        {
            return $@"Cpu: {Cpu}
Operating System: {OperatingSystem}";
        }
    }
}
