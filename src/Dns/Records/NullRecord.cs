﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class NullRecord : IRecord
    {
        public byte[] Data { get; }

        internal NullRecord(Pointer pointer)
        {
            ushort length = (ushort)pointer.ReadShort(-1);
            Data = new byte[length];
            Data = pointer.ReadBytes(length);
        }

        public override string ToString()
        {
            return $"Data: {Data}";
        }
    }
}
