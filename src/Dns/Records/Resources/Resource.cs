using Dns.Classes;
using Dns.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    /// <summary>
    /// (RFC1035 4.1.3)
    /// </summary>
    public class Resource
    {
        internal Resource(Pointer pointer)
        {
            Domain = pointer.ReadDomain();
            Type = TypePool.Find(pointer.ReadShort());
            Class = ClassPool.Find(pointer.ReadShort());
            Ttl = pointer.ReadInt();

            Length = (ushort)pointer.ReadShort();

            if (Type is NullType)
            {
                pointer += Length;
                return;
            }

            Record = RecordFactory.Create(Type, pointer, Length);
        }

        public string Domain { get; }
        internal IDnsType Type { get; }
        internal IDnsClass Class { get; }
        public int Ttl { get; }
        public IRecord Record { get; }
        public ushort Length { get; }
    }
}
