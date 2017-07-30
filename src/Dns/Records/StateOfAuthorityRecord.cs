using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    /// <summary>
    /// (RFC1035 3.3.13)
    /// </summary>
    public class StateOfAuthorityRecord : IRecord
    {
        public string PrimaryNameServer { get; }
        public string ResponsibleMailAddress { get; }
        public int Serial { get; }
        public int Refresh { get; }
        public int Retry { get; }
        public int Expire { get; }
        public int DefaultTtl { get; }

        internal StateOfAuthorityRecord(Pointer pointer)
        {
            PrimaryNameServer = pointer.ReadDomain();
            ResponsibleMailAddress = pointer.ReadDomain();
            Serial = pointer.ReadInt();
            Refresh = pointer.ReadInt();
            Retry = pointer.ReadInt();
            Expire = pointer.ReadInt();
            DefaultTtl = pointer.ReadInt();
        }

        public override string ToString()
        {
            return $@"Primary Name Server: {PrimaryNameServer}
Responsible Mail Address: {ResponsibleMailAddress}
Serial: {Serial}
Refresh: {Refresh}
Retry: {Retry}
Expire: {Expire}
DefaultTtl: {DefaultTtl}";
        }
    }
}
