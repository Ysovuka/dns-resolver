using System;
using System.Collections.Generic;
using System.Text;

namespace Dns.Records
{
    /// <summary>
    /// (RFC1035 3.3.9)
    /// </summary>
    public class MailExchangeRecord : IRecord, IComparable
    {
        public string Domain { get; }
        public int Preference { get; }

        internal MailExchangeRecord(Pointer pointer)
        {
            Preference = pointer.ReadShort();
            Domain = pointer.ReadDomain();
        }

        public override string ToString()
        {
            return $@"Mail Server: {Domain}
Preference: {Preference}";
        }

        public int CompareTo(object obj)
        {
            MailExchangeRecord other = (MailExchangeRecord)obj;

            if (other.Preference < Preference) return 1;
            if (other.Preference > Preference) return -1;

            return other.Domain.CompareTo(Domain);
        }

        public static bool operator==(MailExchangeRecord left, MailExchangeRecord right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));

            return left.Equals(right);
        }

        public static bool operator!=(MailExchangeRecord left, MailExchangeRecord right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            MailExchangeRecord other = (MailExchangeRecord)obj;
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
