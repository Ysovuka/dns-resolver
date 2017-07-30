using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    public class KeyExchangeRecord : IRecord, IComparable
    {
        public int Preference { get; }
        public string Domain { get; }

        internal KeyExchangeRecord(Pointer pointer)
        {
            Preference = pointer.ReadShort();
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Preference: {Preference}
Exchanger: {Domain}";
        }

        public int CompareTo(object obj)
        {
            KeyExchangeRecord other = (KeyExchangeRecord)obj;

            if (other.Preference < Preference) return 1;
            if (other.Preference > Preference) return -1;

            return other.Domain.CompareTo(Domain);
        }

        public static bool operator ==(KeyExchangeRecord left, KeyExchangeRecord right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));

            return left.Equals(right);
        }

        public static bool operator !=(KeyExchangeRecord left, KeyExchangeRecord right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            KeyExchangeRecord other = (KeyExchangeRecord)obj;
            if (other.Preference != Preference) return false;
            if (!other.Domain.Equals(Domain)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Preference;
        }
    }
}
