using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class AddressPrefixListRecord : IRecord
    {
        public short Family { get; }
        public byte Prefix { get; }
        public bool NegationFlag { get; }
        public int Length { get; }
        public byte[] Data { get; }

        internal AddressPrefixListRecord(Pointer pointer)
        {
            Family = pointer.ReadShort();
            Prefix = pointer.ReadByte();

            byte original = pointer.ReadByte();
            NegationFlag = Convert.ToBoolean(original >> 8);
            Length = (original << 1);
            Data = new byte[Length];
            Data = pointer.ReadBytes(Length);
        }

        public override string ToString()
        {
            return $@"Family: {Family}
Prefix: {Prefix}
Length: {Length}
Data: {Data}";
        }
    }
}
