using Dns.Classes;
using Dns.OperationCodes;
using Dns.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dns
{
    internal class DnsQuestion
    {
        internal DnsQuestion()
        {
            RecursionDesired = true;
            OperationCode = OperationCodePool.Find(0);
        }

        internal DnsQuestion(string domain, IDnsType dnsType, IDnsClass dnsClass)
            : this()
        {
            if (string.IsNullOrEmpty(domain)) throw new ArgumentNullException(nameof(domain));
            // do a sanity check on the domain name to make sure its legal
            if (domain.Length > 255)
            {
                // domain names can't be bigger than 255 chars
                throw new ArgumentException("The supplied domain name was too long.", "domain");
            }

            if (dnsType is NullType)
            {
                throw new ArgumentOutOfRangeException(nameof(dnsType), "Not a valid value.");
            }

            if (dnsClass is NullClass)
            {
                throw new ArgumentOutOfRangeException(nameof(dnsClass), "Not a valid value.");
            }

            Domain = domain;
            Type = dnsType;
            Class = dnsClass;
        }

        /// <summary>
        /// Construct the question reading from a DNS Server response. Consult RFC1035 4.1.2
        /// for byte-wise details of this structure in byte array form
        /// </summary>
        /// <param name="pointer">a logical pointer to the Question in byte array form</param>
        internal DnsQuestion(Pointer pointer)
            : this()
        {
            // extract from the message
            Domain = pointer.ReadDomain();
            Type = TypePool.Find(pointer.ReadShort());
            Class = ClassPool.Find(pointer.ReadShort());
        }

        public bool RecursionDesired { get; set; }
        public IDnsOperationCode OperationCode { get; set; }

        public string Domain { get; }
        public IDnsType Type { get; }
        public IDnsClass Class { get; }

        public byte[] GetMessage()
        {
            // construct a message for this request. This will be a byte array but we're using
            // an arraylist as we don't know how big it will be
            ArrayList data = new ArrayList();

            // the id of this message - this will be filled in by the resolver
            data.Add((byte)0);
            data.Add((byte)0);

            // write the bitfields
            data.Add((byte)(((byte)OperationCode.ToInt() << 3) | (RecursionDesired ? 0x01 : 0)));
            data.Add((byte)0);

            // tell it how many questions
            unchecked
            {
                data.Add((byte)(1 >> 8));
                data.Add((byte)1);
            }

            // the are no requests, name servers or additional records in a request
            data.Add((byte)0); data.Add((byte)0);
            data.Add((byte)0); data.Add((byte)0);
            data.Add((byte)0); data.Add((byte)0);

            AddDomain(data, Domain);
            unchecked
            {
                data.Add((byte)0);
                data.Add((byte)Type.ToInt());
                data.Add((byte)0);
                data.Add((byte)Class.ToInt());
            }

            // and convert that to an array
            byte[] message = new byte[data.Count];
            data.CopyTo(message);
            return message;
        }

        /// <summary>
		/// Adds a domain name to the ArrayList of bytes. This implementation does not use
		/// the domain name compression used in the class Pointer - maybe it should.
		/// </summary>
		/// <param name="data">The ArrayList representing the byte array message</param>
		/// <param name="domainName">the domain name to encode and add to the array</param>
		private static void AddDomain(ArrayList data, string domainName)
        {
            int position = 0;
            int length = 0;

            // start from the beginning and go to the end
            while (position < domainName.Length)
            {
                // look for a period, after where we are
                length = domainName.IndexOf('.', position) - position;

                // if there isn't one then this labels length is to the end of the string
                if (length < 0) length = domainName.Length - position;

                // add the length
                data.Add((byte)length);

                // copy a char at a time to the array
                while (length-- > 0)
                {
                    data.Add((byte)domainName[position++]);
                }

                // step over '.'
                position++;
            }

            // end of domain names
            data.Add((byte)0);
        }
    }
}
